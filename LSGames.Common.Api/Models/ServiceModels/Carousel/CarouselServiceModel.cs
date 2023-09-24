namespace LSGames.Common.Api.Models.ServiceModels.Carousel
{
    public class CarouselServiceModel
    {
        /// <summary>
        /// 圖片輪播 PK
        /// </summary>
        public long CarouselId { get; set; }

        /// <summary>
        /// 圖片輪播標題
        /// </summary>
        public string? CarouselTitle { get; set; }

        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string CarouselImagePath { get; set; } = null!;

        /// <summary>
        /// 圖片描述
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// 連結
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// 建立使用者帳號 PK
        /// </summary>
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 最後更新使用者帳號 PK
        /// </summary>
        public long? UpdatedUserId { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
