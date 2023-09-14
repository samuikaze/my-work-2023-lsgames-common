namespace LSGames.Common.Api.Models.ServiceModels
{
    public class GetPaginatorEntitiesRequestServiceModel
    {
        /// <summary>
        /// 目前頁碼
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 每頁筆數
        /// </summary>
        public int? RowPerPage { get; set; }
    }
}
