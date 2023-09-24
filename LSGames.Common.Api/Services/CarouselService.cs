using LSGames.Common.Api.Models.ServiceModels.Carousel;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Repository.Repositories.Carousel;
using AutoMapper;
using LSGames.Common.Repository.Models;

namespace LSGames.Common.Api.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly IMapper _mapper;
        private ICarouselRepository _carouselRepository;
        private int _defaultRowPerPage = 10;

        public CarouselService(
            IMapper mapper,
            ICarouselRepository carouselRepository)
        {
            _mapper = mapper;
            _carouselRepository = carouselRepository;
        }

        /// <summary>
        /// 取得圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetCarouselListResponseServiceModel> GetCarouselList(GetPaginatorEntitiesRequestServiceModel request)
        {
            int page = request.Page ?? 1;
            int rowPerPage = request.RowPerPage ?? _defaultRowPerPage;
            int skip = (page - 1) * rowPerPage;

            var caarousels = _mapper.Map<List<CarouselServiceModel>>(
                await _carouselRepository.GetCarouselList(skip, rowPerPage));
            int totalFaqs = await _carouselRepository.GetTotalFaqRows();

            return new GetCarouselListResponseServiceModel()
            {
                CarouselList = caarousels,
                TotalPages = (int)Math.Ceiling((double)totalFaqs / rowPerPage),
            };
        }

        /// <summary>
        /// 新增圖片輪播
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CarouselServiceModel> CreateCarousel(UserServiceModel user, CarouselServiceModel request)
        {
            request.CreatedUserId = user.Id;
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedUserId = user.Id;
            request.UpdatedAt = DateTime.UtcNow;
            var carousel = _mapper.Map<Carousel>(request);

            await _carouselRepository.CreateAsync(carousel);

            return _mapper.Map<CarouselServiceModel>(carousel);
        }

        /// <summary>
        /// 更新圖片輪播
        /// </summary>
        /// <param name="user"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CarouselServiceModel> UpdateCarousel(UserServiceModel user, CarouselServiceModel request)
        {
            var carousel = await _carouselRepository.GetCarousel(request.CarouselId);
            carousel.CarouselTitle = request.CarouselTitle;
            carousel.CarouselImagePath = request.CarouselImagePath;
            carousel.Description = request.Description;
            carousel.Link = request.Link;
            carousel.UpdatedUserId = user.Id;
            carousel.UpdatedAt = DateTime.UtcNow;

            await _carouselRepository.UpdateAsync(carousel);

            return _mapper.Map<CarouselServiceModel>(carousel);
        }

        /// <summary>
        /// 刪除圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> DeleteCarousel(CarouselServiceModel request)
        {
            var carousel = await _carouselRepository.GetCarousel(request.CarouselId);

            return await _carouselRepository.DeleteAsync(carousel);
        }
    }
}
