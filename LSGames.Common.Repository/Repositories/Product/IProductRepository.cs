using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public interface IProductRepository : IGenericRepository<Models.Product>
    {
        /// <summary>
        /// 取得作品一覽
        /// </summary>
        /// <param name="skip">跳過筆數</param>
        /// <param name="rowPerPage">每頁筆數</param>
        /// <returns></returns>
        public Task<List<Models.Product>> GetProductList(int skip, int rowPerPage);

        /// <summary>
        /// 取得作品總筆數
        /// </summary>
        /// <returns></returns>
        public Task<int> GetTotalProducts();
    }
}
