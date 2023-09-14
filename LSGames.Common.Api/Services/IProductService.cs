using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Product;

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
