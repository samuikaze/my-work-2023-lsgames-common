using LSGames.Common.Api.Models.ServiceModels.Faq;

namespace LSGames.Common.Api.Models.ServiceModels.Carousel
{
    public class GetCarouselListResponseServiceModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<CarouselServiceModel> CarouselList { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
