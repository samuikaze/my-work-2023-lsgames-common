using LSGames.Common.Api.Models.ServiceModels.News;

namespace LSGames.Common.Api.Models.ServiceModels.Product
{
    public class GetProductsResponseServiceModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<ProductServiceModel> ProductList { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
