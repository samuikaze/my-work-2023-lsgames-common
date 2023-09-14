namespace LSGames.Common.Api.Models.ServiceModels.News
{
    public class GetNewsResponseServiceModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<NewsServiceModel> NewsList { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
