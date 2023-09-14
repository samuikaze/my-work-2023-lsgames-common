using AutoMapper;
using LSGames.Common.Api.Filters;
using LSGames.Common.Api.Models.ViewModels;
using LSGames.Common.Api.Models.ViewModels.News;
using LSGames.Common.Api.Models.ServiceModels.News;
using LSGames.Common.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using LSGames.Common.Api.Models.ServiceModels;

namespace LSGames.Common.Api.Controllers
{
    [ApiController]
    [Route("news")]
    [SwaggerTag("最新消息")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly IMapper _mapper;
        private readonly INewsService _newsService;

        public NewsController(
            ILogger<NewsController> logger,
            IMapper mapper,
            INewsService newsService)
        {
            _logger = logger;
            _mapper = mapper;
            _newsService = newsService;
        }

        /// <summary>
        /// 取得最新消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<GetNewsResponseViewModel> GetNewsList([FromQuery] GetPaginatorEntitiesRequestViewModel request)
        {
            return _mapper.Map<GetNewsResponseViewModel>(
                await _newsService.GetNewsList(
                    _mapper.Map<GetPaginatorEntitiesRequestServiceModel>(request)));
        }

        /// <summary>
        /// 取得所有最新消息種類
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<List<NewsTypeViewModel>> GetNewsTypes()
        {
            return _mapper.Map<List<NewsTypeViewModel>>(
                await _newsService.GetNewsTypes());
        }

        /// <summary>
        /// 依據最新消息 PK 取得最新消息
        /// </summary>
        /// <param name="newsId">最新消息 PK</param>
        /// <returns></returns>
        [HttpGet("{newsId}")]
        public async Task<ActionResult<NewsViewModel>> GetNews([FromRoute] int newsId)
        {
            try
            {
                return Ok(_mapper.Map<NewsViewModel>(
                    await _newsService.GetNews(newsId)));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(
                    new ExceptionResponseViewModel()
                    {
                        Code = 400,
                        Message = ex.Message,
                        Errors = ex.GetType().Name
                    });
            }
        }

        /// <summary>
        /// 新增消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> CreateNews([FromBody] NewsViewModel request)
        {
            return await _newsService.CreateNews(
                _mapper.Map<NewsServiceModel>(request));
        }

        /// <summary>
        /// 更新消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> UpdateNews([FromBody] NewsViewModel request)
        {
            return await _newsService.UpdateNews(
                _mapper.Map<NewsServiceModel>(request));
        }

        /// <summary>
        /// 刪除消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> DeleteNews([FromBody] NewsViewModel request)
        {
            return await _newsService.DeleteNews(
                _mapper.Map<NewsServiceModel>(request));
        }
    }
}
