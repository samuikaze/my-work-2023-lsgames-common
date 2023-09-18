using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Faq
{
    public interface IFaqRepository : IGenericRepository<Models.Faq>
    {
        /// <summary>
        /// 取得常見問題
        /// </summary>
        /// <param name="skip">跳過筆數</param>
        /// <param name="rowPerPage">每頁筆數</param>
        /// <returns></returns>
        public Task<List<Models.Faq>> GetFaqList(int skip, int rowPerPage);

        /// <summary>
        /// 取得常見問題總筆數
        /// </summary>
        /// <returns></returns>
        public Task<int> GetTotalFaqRows();

        /// <summary>
        /// 依據常見問題 PK 取得常見問題
        /// </summary>
        /// <param name="faqId">常見問題 PK</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<Models.Faq> GetFaq(long faqId);
    }
}
