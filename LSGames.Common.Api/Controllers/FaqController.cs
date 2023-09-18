using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ViewModels;
using LSGames.Common.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using LSGames.Common.Api.Models.ViewModels.Faq;
using LSGames.Common.Api.Filters;
using LSGames.Common.Api.Models.ServiceModels.Faq;

namespace LSGames.Common.Api.Controllers
{
    [ApiController]
    [Route("faq")]
    [SwaggerTag("常見問題")]
    public class FaqController : ControllerBase
    {
        private readonly ILogger<FaqController> _logger;
        private readonly IMapper _mapper;
        private readonly IFaqService _faqService;

        public FaqController(
            ILogger<FaqController> logger,
            IMapper mapper,
            IFaqService faqService)
        {
            _logger = logger;
            _mapper = mapper;
            _faqService = faqService;
        }

        /// <summary>
        /// 取得常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<GetFaqListResponseViewModel> GetFaqList([FromQuery] GetPaginatorEntitiesRequestViewModel request)
        {
            return _mapper.Map<GetFaqListResponseViewModel>(
                await _faqService.GetFaqList(
                    _mapper.Map<GetPaginatorEntitiesRequestServiceModel>(request)));
        }

        /// <summary>
        /// 新增常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> CreateFaq([FromBody] FaqViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return await _faqService.CreateFaq(
                user.Id,
                _mapper.Map<FaqServiceModel>(request));
        }

        /// <summary>
        /// 更新常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> UpdateFaq([FromBody] FaqViewModel request)
        {
            UserServiceModel user = (UserServiceModel)HttpContext.Items["User"]!;

            return await _faqService.UpdateFaq(
                user.Id,
                _mapper.Map<FaqServiceModel>(request));
        }

        /// <summary>
        /// 刪除常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("")]
        [TypeFilter(typeof(VerifyAccessTokenAuthorizeAttribute))]
        public async Task<int> DeleteFaq([FromBody] FaqViewModel request)
        {
            return await _faqService.DeleteFaq(
                _mapper.Map<FaqServiceModel>(request));
        }
    }
}
