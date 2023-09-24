using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Carousel
{
    public interface ICarouselRepository : IGenericRepository<Models.Carousel>
    {
        /// <summary>
        /// 取得圖片輪播
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="rowPerPage"></param>
        /// <returns></returns>
        public Task<List<Models.Carousel>> GetCarouselList(int skip, int rowPerPage);

        /// <summary>
        /// 取得圖片輪播總筆數
        /// </summary>
        /// <returns></returns>
        public Task<int> GetTotalFaqRows();

        /// <summary>
        /// 依據圖片輪播 PK 取得圖片輪播
        /// </summary>
        /// <param name="carouselId">圖片輪播 PK</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Task<Models.Carousel> GetCarousel(long carouselId);
    }
}
