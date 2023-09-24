using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.Product
{
    public interface IProductTypeRepository : IGenericRepository<ProductType>
    {
        /// <summary>
        /// 依據作品分類 PK 取得作品分類資料
        /// </summary>
        /// <param name="id">作品分類 PK</param>
        /// <returns></returns>
        public Task<ProductType?> GetProductTypeById(long id);
    }
}
