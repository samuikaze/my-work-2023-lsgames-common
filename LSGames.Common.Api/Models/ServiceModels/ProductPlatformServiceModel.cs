namespace LSGames.Common.Api.Models.ServiceModels
{
    public class ProductPlatformServiceModel
    {
        /// <summary>
        /// 作品平台 PK
        /// </summary>
        public long ProductPlatformId { get; set; }

        /// <summary>
        /// 作品平台名稱
        /// </summary>
        public string ProductPlatformName { get; set; } = null!;

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
