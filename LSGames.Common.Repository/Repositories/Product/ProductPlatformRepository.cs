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
    public class ProductPlatformRepository : GenericRepository<ProductPlatform>, IProductPlatformRepository
    {
        private LsgamesCommonsContext _context;

        public ProductPlatformRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 依據作品平台 PK 取得作品平台資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductPlatform?> GetProductPlatformById(long id)
        {
            return await _context.ProductPlatforms
                .Where(productPlatform => productPlatform.ProductPlatformId == id)
                .FirstOrDefaultAsync();
        }
    }
}
