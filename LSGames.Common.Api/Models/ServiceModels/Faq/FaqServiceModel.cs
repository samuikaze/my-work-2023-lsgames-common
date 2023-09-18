namespace LSGames.Common.Api.Models.ServiceModels.Faq
{
    public class FaqServiceModel
    {
        /// <summary>
        /// 常見問題 PK
        /// </summary>
        public long FaqId { get; set; }

        /// <summary>
        /// 常見問題-問題
        /// </summary>
        public string FaqQuestion { get; set; } = null!;

        /// <summary>
        /// 常見問題-解答
        /// </summary>
        public string FaqAnswer { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 建立使用者帳號 PK
        /// </summary>
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// 最後更新使用者帳號 PK
        /// </summary>
        public long? UpdatedUserId { get; set; }
    }
}
