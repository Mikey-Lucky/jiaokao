using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlCoat : ICoat
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IQueryable<Coat> CoatBySeason(string season)
        {
            var coat = from c in db.Coat
                        where c.Season == season
                        select c;
            return coat;
        }
    }
}
