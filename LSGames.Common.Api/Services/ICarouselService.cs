using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Carousel;

namespace LSGames.Common.Api.Services
{
    public interface ICarouselService
    {
        /// <summary>
        /// 取得圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<GetCarouselListResponseServiceModel> GetCarouselList(GetPaginatorEntitiesRequestServiceModel request);

        /// <summary>
        /// 新增圖片輪播
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CarouselServiceModel> CreateCarousel(UserServiceModel user, CarouselServiceModel request);

        /// <summary>
        /// 更新圖片輪播
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<CarouselServiceModel> UpdateCarousel(UserServiceModel user, CarouselServiceModel request);

        /// <summary>
        /// 刪除圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> DeleteCarousel(CarouselServiceModel request);
    }
}
