using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Faq;
using LSGames.Common.Api.Models.ServiceModels.News;
using LSGames.Common.Repository.Repositories.Faq;

namespace LSGames.Common.Api.Services
{
    public class FaqService : IFaqService
    {
        private readonly IMapper _mapper;
        private IFaqRepository _faqRepository;
        private int _defaultRowPerPage = 10;

        public FaqService(
            IMapper mapper,
            IFaqRepository faqRepository)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
        }

        /// <summary>
        /// 取得常見問題清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetFaqListResponseServiceModel> GetFaqList(GetPaginatorEntitiesRequestServiceModel request)
        {
            int page = request.Page ?? 1;
            int rowPerPage = request.RowPerPage ?? _defaultRowPerPage;
            int skip = (page - 1) * rowPerPage;

            var faqs = _mapper.Map<List<FaqServiceModel>>(
                await _faqRepository.GetFaqList(skip, rowPerPage));
            int totalFaqs = await _faqRepository.GetTotalFaqRows();

            return new GetFaqListResponseServiceModel()
            {
                FaqList = faqs,
                TotalPages = (int)Math.Ceiling((double)totalFaqs / rowPerPage),
            };
        }

        /// <summary>
        /// 新增常見問題
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CreateFaq(long userId, FaqServiceModel request)
        {

            request.CreatedAt = DateTime.UtcNow;
            request.CreatedUserId = userId;
            request.UpdatedAt = DateTime.UtcNow;
            request.UpdatedUserId = userId;
            var faq = _mapper.Map<Repository.Models.Faq>(request);

            return await _faqRepository.CreateAsync(faq);
        }

        /// <summary>
        /// 更新常見問題
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateFaq(long userId, FaqServiceModel request)
        {
            var faq = await _faqRepository.GetFaq(request.FaqId);
            faq.FaqQuestion = request.FaqQuestion;
            faq.FaqAnswer = request.FaqAnswer;
            faq.UpdatedUserId = userId;
            faq.UpdatedAt = DateTime.UtcNow;

            return await _faqRepository.UpdateAsync(faq);
        }

        /// <summary>
        /// 刪除常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> DeleteFaq(FaqServiceModel request)
        {
            var faq = await _faqRepository.GetFaq(request.FaqId);

            return await _faqRepository.DeleteAsync(faq);
        }
    }
}
