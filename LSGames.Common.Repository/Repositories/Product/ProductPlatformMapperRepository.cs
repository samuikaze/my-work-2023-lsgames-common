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
    public class ProductPlatformMapperRepository : GenericRepository<ProductPlatformMapper>, IProductPlatformMapperRepository
    {
        private LsgamesCommonsContext _context;

        public ProductPlatformMapperRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 以作品 PKs 取得作品平台資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<ProductPlatformMapper>> GetProductPlatformsByIds(List<long> ids)
        {
            return await _context.ProductPlatformMappers
                .Where(ppm => ids.Contains(ppm.ProductId))
                .ToListAsync();
        }
    }
}
