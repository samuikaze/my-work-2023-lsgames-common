using LSGames.Common.Api.Models.ServiceModels.Carousel;

namespace LSGames.Common.Api.Models.ViewModels.Carousel
{
    public class GetCarouselListResponseViewModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<CarouselViewModel> CarouselList { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
