using LSGames.Common.Api.Models.ServiceModels.Product;

namespace LSGames.Common.Api.Models.ViewModels.Product
{
    public class GetProductTypesResponseViewModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<ProductTypeServiceModel> ProductTypeList { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
