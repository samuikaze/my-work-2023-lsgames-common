using LSGames.Common.Repository.DBContexts;
using LSGames.Common.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public class ProductRepository : GenericRepository<Models.Product>, IProductRepository
    {
        private LsgamesCommonsContext _context;

        public ProductRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得作品一覽
        /// </summary>
        /// <param name="skip">跳過筆數</param>
        /// <param name="rowPerPage">每頁筆數</param>
        /// <returns></returns>
        public async Task<List<Models.Product>> GetProductList(int skip, int rowPerPage)
        {
            return await _context.Products
                .Skip(skip)
                .Take(rowPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// 取得作品總筆數
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalProducts()
        {
            return await _context.Products.CountAsync();
        }
    }
}
