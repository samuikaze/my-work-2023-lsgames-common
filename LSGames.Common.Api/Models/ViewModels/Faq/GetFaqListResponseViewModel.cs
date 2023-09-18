using LSGames.Common.Api.Models.ServiceModels.Faq;

namespace LSGames.Common.Api.Models.ViewModels.Faq
{
    public class GetFaqListResponseViewModel
    {
        /// <summary>
        /// 最新消息清單
        /// </summary>
        public List<FaqServiceModel> FaqList { get; set; }

        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }
    }
}
