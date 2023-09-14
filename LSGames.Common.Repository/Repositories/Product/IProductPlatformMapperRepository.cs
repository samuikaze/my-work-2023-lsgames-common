using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public interface IProductPlatformMapperRepository : IGenericRepository<ProductPlatformMapper>
    {
        /// <summary>
        /// 以作品 PKs 取得作品平台資料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<ProductPlatformMapper>> GetProductPlatformsByIds(List<long> ids);
    }
}
