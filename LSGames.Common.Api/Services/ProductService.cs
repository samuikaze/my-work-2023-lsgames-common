using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Product;
using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Product;

namespace LSGames.Common.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;
        private IProductTypeRepository _productTypeRepository;
        private IProductPlatformMapperRepository _productPlatformMapperRepository;
        private IProductPlatformRepository _productPlatformRepository;
        private int _defaultRowPerPage = 10;

        public ProductService(
            ILogger<ProductService> logger,
            IMapper mapper,
            IProductRepository productRepository,
            IProductTypeRepository productTypeRepository,
            IProductPlatformMapperRepository productPlatformMapperRepository,
            IProductPlatformRepository productPlatformRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productPlatformMapperRepository = productPlatformMapperRepository;
            _productPlatformRepository = productPlatformRepository;
        }

        /// <summary>
        /// 取得作品清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetProductsResponseServiceModel> GetProduct(GetPaginatorEntitiesRequestServiceModel request)
        {
            int page = request.Page ?? 1;
            int rowPerPage = request.RowPerPage ?? _defaultRowPerPage;
            int skip = (page - 1) * rowPerPage;

            var products = _mapper.Map<List<ProductServiceModel>>(
                await _productRepository.GetProductList(skip, rowPerPage));

            var productPlatforms = await _productPlatformMapperRepository.GetProductPlatformsByIds(
                products.Select(p => p.ProductId).ToList());

            foreach (var product in products)
            {
                product.ProductPlatforms = productPlatforms
                    .Where(ppf => ppf.ProductId == product.ProductId)
                    .Select(ppf => ppf.ProductPlatformId)
                    .ToList();
            }

            int totalProducts = await _productRepository.GetTotalProducts();

            return new GetProductsResponseServiceModel()
            {
                ProductList = products,
                TotalPages = totalProducts
            };
        }

        /// <summary>
        /// 取得作品平台清單
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductPlatformServiceModel>> GetProductPlatformList()
        {
            return _mapper.Map<List<ProductPlatformServiceModel>>(
                await _productPlatformRepository.GetAsync());
        }

        /// <summary>
        /// 新增作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ProductPlatformServiceModel> CreateProductPlatform(ProductPlatformServiceModel request)
        {
            var productPlatform = _mapper.Map<ProductPlatform>(request);
            productPlatform.CreatedAt = DateTime.UtcNow;
            productPlatform.UpdatedAt = DateTime.UtcNow;

            await _productPlatformRepository.CreateAsync(productPlatform);

            return _mapper.Map<ProductPlatformServiceModel>(productPlatform);
        }

        /// <summary>
        /// 更新作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<ProductPlatformServiceModel> UpdateProductPlatform(ProductPlatformServiceModel request)
        {
            var productPlatform = await _productPlatformRepository.GetProductPlatformById(request.ProductPlatformId);

            if (productPlatform == null)
            {
                throw new NullReferenceException("找不到該作品平台");
            }

            productPlatform.ProductPlatformName = request.ProductPlatformName;
            productPlatform.UpdatedAt = DateTime.UtcNow;

            await _productPlatformRepository.UpdateAsync(productPlatform);

            return _mapper.Map<ProductPlatformServiceModel>(productPlatform);
        }

        /// <summary>
        /// 刪除作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<int> DeleteProductPlatform(ProductPlatformServiceModel request)
        {
            var productPlatform = await _productPlatformRepository.GetProductPlatformById(request.ProductPlatformId);

            if (productPlatform == null)
            {
                throw new NullReferenceException("找不到該作品平台");
            }

            return await _productPlatformRepository.DeleteAsync(productPlatform);
        }

        /// <summary>
        /// 取得作品分類清單
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductTypeServiceModel>> GetProductTypes()
        {
            return _mapper.Map<List<ProductTypeServiceModel>>(
                await _productTypeRepository.GetAsync());
        }

        /// <summary>
        /// 新增作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ProductTypeServiceModel> CreateProductType(ProductTypeServiceModel request)
        {
            var productType = _mapper.Map<ProductType>(request);
            productType.CreatedAt = DateTime.UtcNow;
            productType.UpdatedAt = DateTime.UtcNow;

            await _productTypeRepository.CreateAsync(productType);

            return _mapper.Map<ProductTypeServiceModel>(productType);
        }

        /// <summary>
        /// 更新作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<ProductTypeServiceModel> UpdateProductType(ProductTypeServiceModel request)
        {
            var productType = await _productTypeRepository.GetProductTypeById(request.ProductTypeId);

            if (productType == null)
            {
                throw new NullReferenceException("找不到該作品分類");
            }

            productType.ProductTypeName = request.ProductTypeName;
            productType.UpdatedAt = DateTime.UtcNow;

            await _productTypeRepository.UpdateAsync(productType);

            return _mapper.Map<ProductTypeServiceModel>(productType);
        }

        /// <summary>
        /// 刪除作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<int> DeleteProductType(ProductTypeServiceModel request)
        {
            var productType = await _productTypeRepository.GetProductTypeById(request.ProductTypeId);

            if (productType == null)
            {
                throw new NullReferenceException("找不到該作品分類");
            }

            return await _productTypeRepository.DeleteAsync(productType);
        }

        /// <summary>
        /// 新增作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> CreateProduct(CreateProductRequestServiceModel request)
        {
            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            await _productRepository.CreateAsync(product);

            return true;
        }

        /// <summary>
        /// 更新作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateProduct(ProductServiceModel request)
        {
            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            int effected = await _productRepository.UpdateAsync(product);

            return effected;
        }

        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> DeleteProduct(ProductServiceModel request)
        {
            return await _productRepository.DeleteAsync(
                _mapper.Map<Product>(request));
        }
    }
}
