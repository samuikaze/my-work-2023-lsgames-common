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
    }
}
