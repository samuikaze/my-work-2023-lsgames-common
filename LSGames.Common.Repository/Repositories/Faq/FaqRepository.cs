using LSGames.Common.Repository.DBContexts;
using LSGames.Common.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Faq
{
    public class FaqRepository : GenericRepository<Models.Faq>, IFaqRepository
    {
        private LsgamesCommonsContext _context;

        public FaqRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得常見問題
        /// </summary>
        /// <param name="skip">跳過筆數</param>
        /// <param name="rowPerPage">每頁筆數</param>
        /// <returns></returns>
        public async Task<List<Models.Faq>> GetFaqList(int skip, int rowPerPage)
        {
            return await _context.Faqs
                .Skip(skip)
                .Take(rowPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// 取得常見問題總筆數
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalFaqRows()
        {
            return await _context.Faqs.CountAsync();
        }

        /// <summary>
        /// 依據常見問題 PK 取得常見問題
        /// </summary>
        /// <param name="faqId">常見問題 PK</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Models.Faq> GetFaq(long faqId)
        {
            var faq = await _context.Faqs
                .Where(faqEntity => faqEntity.FaqId == faqId)
                .FirstOrDefaultAsync();

            if (faq == null)
            {
                throw new NullReferenceException("找不到該常見問題");
            }

            return faq;
        }
    }
}
