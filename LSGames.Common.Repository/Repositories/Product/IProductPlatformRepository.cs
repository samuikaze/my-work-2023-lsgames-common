using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public interface IProductPlatformRepository : IGenericRepository<ProductPlatform>
    {
        /// <summary>
        /// 依據作品平台 PK 取得作品平台資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ProductPlatform?> GetProductPlatformById(long id);
    }
}
