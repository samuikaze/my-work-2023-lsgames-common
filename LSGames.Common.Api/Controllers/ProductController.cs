using AutoMapper;
using LSGames.Common.Api.Filters;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Product;
using LSGames.Common.Api.Models.ViewModels;
using LSGames.Common.Api.Models.ViewModels.Product;
using LSGames.Common.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LSGames.Common.Api.Controllers
{
    [ApiController]
    [Route("product")]
    [SwaggerTag("作品一覽")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IMapper mapper,
            IProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// 取得作品清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<GetProductsResponseViewModel> GetProducts([FromQuery] GetPaginatorEntitiesRequestViewModel request)
        {
            return _mapper.Map<GetProductsResponseViewModel>(
                await _productService.GetProduct(
                    _mapper.Map<GetPaginatorEntitiesRequestServiceModel>(request)));
        }

        /// <summary>
        /// 取得作品平台清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("platforms")]
        public async Task<List<ProductPlatformViewModel>> GetProductPlatformList()
        {
            return _mapper.Map<List<ProductPlatformViewModel>>(
                await _productService.GetProductPlatformList());
        }

        /// <summary>
        /// 新增作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("platform")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ProductPlatformViewModel> CreateProductPlatform([FromBody] ProductPlatformViewModel request)
        {
            return _mapper.Map<ProductPlatformViewModel>(
                await _productService.CreateProductPlatform(
                    _mapper.Map<ProductPlatformServiceModel>(request)));
        }

        /// <summary>
        /// 更新作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("platform")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<ProductPlatformViewModel>> UpdateProductPlatform([FromBody] ProductPlatformViewModel request)
        {
            try
            {
                return Ok(_mapper.Map<ProductPlatformViewModel>(
                    await _productService.UpdateProductPlatform(
                        _mapper.Map<ProductPlatformServiceModel>(request))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 刪除作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("platform")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<int>> DeleteProductPlatform([FromBody] ProductPlatformViewModel request)
        {
            try
            {
                return Ok(
                    await _productService.DeleteProductPlatform(
                        _mapper.Map<ProductPlatformServiceModel>(request)));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 新增作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<bool> CreateProduct([FromBody] CreateProductRequestViewModel request)
        {
            return await _productService.CreateProduct(
                _mapper.Map<CreateProductRequestServiceModel>(request));
        }

        /// <summary>
        /// 取得作品分類清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<List<ProductTypeViewModel>> GetProductTypes()
        {
            return _mapper.Map<List<ProductTypeViewModel>>(
                await _productService.GetProductTypes());
        }

        /// <summary>
        /// 新增作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("type")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ProductTypeViewModel> CreateProductType([FromBody] ProductTypeViewModel request)
        {
            return _mapper.Map<ProductTypeViewModel>(
                await _productService.CreateProductType(
                    _mapper.Map<ProductTypeServiceModel>(request)));
        }

        /// <summary>
        /// 更新作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("type")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<ProductTypeViewModel>> UpdateProductType([FromBody] ProductTypeViewModel request)
        {
            try
            {
                return Ok(_mapper.Map<ProductTypeViewModel>(
                    await _productService.UpdateProductType(
                        _mapper.Map<ProductTypeServiceModel>(request))));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 刪除作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("type")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<ActionResult<int>> DeleteProdcutType([FromBody] ProductTypeViewModel request)
        {
            try
            {
                return Ok(await _productService.DeleteProductType(
                    _mapper.Map<ProductTypeServiceModel>(request)));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 更新作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> UpdateProduct([FromBody] ProductViewModel request)
        {
            return await _productService.UpdateProduct(
                _mapper.Map<ProductServiceModel>(request));
        }

        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> DeleteProduct([FromBody] ProductViewModel request)
        {
            return await _productService.DeleteProduct(
                _mapper.Map<ProductServiceModel>(request));
        }
    }
}
