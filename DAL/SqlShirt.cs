using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlShirt : IShirt
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IQueryable<Shirt> ShirtBySeason(string season)
        {
            var shirt = from s in db.Shirt
                        where s.Season == season
                        select s;
            return shirt;
        }
    }
}
