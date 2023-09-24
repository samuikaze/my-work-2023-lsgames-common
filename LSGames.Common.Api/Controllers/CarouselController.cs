using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ViewModels.Faq;
using LSGames.Common.Api.Models.ViewModels;
using LSGames.Common.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using LSGames.Common.Api.Models.ViewModels.Carousel;
using LSGames.Common.Api.Filters;
using LSGames.Common.Api.Models.ServiceModels.Carousel;

namespace LSGames.Common.Api.Controllers
{
    [ApiController]
    [Route("carousel")]
    [SwaggerTag("圖片輪播")]
    public class CarouselController : ControllerBase
    {
        private readonly ILogger<CarouselController> _logger;
        private readonly IMapper _mapper;
        private ICarouselService _carouselService;

        public CarouselController(
            ILogger<CarouselController> logger,
            IMapper mapper,
            ICarouselService carouselService)
        {
            _logger = logger;
            _mapper = mapper;
            _carouselService = carouselService;
        }

        /// <summary>
        /// 取得圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<GetCarouselListResponseViewModel> GetCarouselList([FromQuery] GetPaginatorEntitiesRequestViewModel request)
        {
            return _mapper.Map<GetCarouselListResponseViewModel>(
                await _carouselService.GetCarouselList(
                    _mapper.Map<GetPaginatorEntitiesRequestServiceModel>(request)));
        }

        /// <summary>
        /// 新增圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<CarouselViewModel> CreateCarousel([FromBody] CarouselViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return _mapper.Map<CarouselViewModel>(
                await _carouselService.CreateCarousel(
                    user,
                    _mapper.Map<CarouselServiceModel>(request)));
        }

        /// <summary>
        /// 更新圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<CarouselViewModel> UpdateCarousel([FromBody] CarouselViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;
            return _mapper.Map<CarouselViewModel>(
                await _carouselService.UpdateCarousel(
                    user,
                    _mapper.Map<CarouselServiceModel>(request)));
        }

        /// <summary>
        /// 刪除圖片輪播
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> DeleteCarousel([FromBody] CarouselViewModel request)
        {
            return await _carouselService.DeleteCarousel(
                _mapper.Map<CarouselServiceModel>(request));
        }
    }
}
