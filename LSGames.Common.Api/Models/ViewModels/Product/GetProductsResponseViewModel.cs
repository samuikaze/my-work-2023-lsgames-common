namespace LSGames.Common.Api.Models.ViewModels.Product
{
    public class GetProductsResponseViewModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<ProductViewModel> ProductList { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
