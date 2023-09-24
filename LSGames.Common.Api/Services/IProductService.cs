using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Product;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.Services
{
    public interface IProductService
    {
        /// <summary>
        /// 取得作品清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<GetProductsResponseServiceModel> GetProduct(GetPaginatorEntitiesRequestServiceModel request);

        /// <summary>
        /// 取得作品平台清單
        /// </summary>
        /// <returns></returns>
        public Task<List<ProductPlatformServiceModel>> GetProductPlatformList();

        /// <summary>
        /// 新增作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<ProductPlatformServiceModel> CreateProductPlatform(ProductPlatformServiceModel request);

        /// <summary>
        /// 更新作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<ProductPlatformServiceModel> UpdateProductPlatform(ProductPlatformServiceModel request);

        /// <summary>
        /// 刪除作品平台
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<int> DeleteProductPlatform(ProductPlatformServiceModel request);

        /// <summary>
        /// 新增作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<bool> CreateProduct(CreateProductRequestServiceModel request);

        /// <summary>
        /// 取得作品分類清單
        /// </summary>
        /// <returns></returns>
        public Task<List<ProductTypeServiceModel>> GetProductTypes();

        /// <summary>
        /// 新增作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<ProductTypeServiceModel> CreateProductType(ProductTypeServiceModel request);

        /// <summary>
        /// 更新作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<ProductTypeServiceModel> UpdateProductType(ProductTypeServiceModel request);

        /// <summary>
        /// 刪除作品分類
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<int> DeleteProductType(ProductTypeServiceModel request);

        /// <summary>
        /// 更新作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> UpdateProduct(ProductServiceModel request);

        /// <summary>
        /// 刪除作品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> DeleteProduct(ProductServiceModel request);
    }
}
