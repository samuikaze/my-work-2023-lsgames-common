using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.Faq;

namespace LSGames.Common.Api.Services
{
    public interface IFaqService
    {
        /// <summary>
        /// 取得常見問題清單
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<GetFaqListResponseServiceModel> GetFaqList(GetPaginatorEntitiesRequestServiceModel request);

        /// <summary>
        /// 新增常見問題
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> CreateFaq(long userId, FaqServiceModel request);

        /// <summary>
        /// 更新常見問題
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> UpdateFaq(long userId, FaqServiceModel request);

        /// <summary>
        /// 刪除常見問題
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> DeleteFaq(FaqServiceModel request);
    }
}
