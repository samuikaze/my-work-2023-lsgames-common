namespace LSGames.Common.Api.Models.ViewModels.News
{
    public class NewsTypeViewModel
    {
        /// <summary>
        /// 最新消息種類 PK
        /// </summary>
        public long NewsTypeId { get; set; }

        /// <summary>
        /// 最新消息種類名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 建立帳號 PK
        /// </summary>
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 最後更新帳號 PK
        /// </summary>
        public long? UpdatedUserId { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
