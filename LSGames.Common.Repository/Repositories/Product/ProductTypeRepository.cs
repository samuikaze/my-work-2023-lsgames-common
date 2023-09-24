using LSGames.Common.Repository.DBContexts;
using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        private LsgamesCommonsContext _context;

        public ProductTypeRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 依據作品分類 PK 取得作品分類資料
        /// </summary>
        /// <param name="id">作品分類 PK</param>
        /// <returns></returns>
        public async Task<ProductType?> GetProductTypeById(long id)
        {
            return await  _context.ProductTypes
                .Where(productType => productType.ProductTypeId == id)
                .FirstOrDefaultAsync();
        }
    }
}
