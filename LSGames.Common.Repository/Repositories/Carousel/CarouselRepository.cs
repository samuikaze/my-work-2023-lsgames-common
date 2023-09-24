using LSGames.Common.Repository.DBContexts;
using LSGames.Common.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Carousel
{
    public class CarouselRepository : GenericRepository<Models.Carousel>, ICarouselRepository
    {
        private LsgamesCommonsContext _context;

        public CarouselRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得圖片輪播
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="rowPerPage"></param>
        /// <returns></returns>
        public async Task<List<Models.Carousel>> GetCarouselList(int skip, int rowPerPage)
        {
            return await _context.Carousels
                .Skip(skip)
                .Take(rowPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// 取得圖片輪播總筆數
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalFaqRows()
        {
            return await _context.Carousels.CountAsync();
        }

        /// <summary>
        /// 依據圖片輪播 PK 取得圖片輪播
        /// </summary>
        /// <param name="carouselId">圖片輪播 PK</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Models.Carousel> GetCarousel(long carouselId)
        {
            var faq = await _context.Carousels
                .Where(faqEntity => faqEntity.CarouselId == carouselId)
                .FirstOrDefaultAsync();

            if (faq == null)
            {
                throw new NullReferenceException("找不到該圖片輪播");
            }

            return faq;
        }
    }
}
