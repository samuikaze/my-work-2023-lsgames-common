using LSGames.Common.Repository.DBContexts;
using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSGames.Common.Repository.Repositories.News
{
    public class NewsTypeRepository : GenericRepository<NewsType>, INewsTypeRepository
    {
        private LsgamesCommonsContext _context;
        public NewsTypeRepository(LsgamesCommonsContext context) : base(context)
        {
            _context = context;
        }
    }
}
