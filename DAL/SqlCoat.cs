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

        public IQueryable<Coat> CoatByTemp(int temp)
        {
            IQueryable<Coat> coat;
            if (temp < 5)
            {
                 coat = from c in db.Coat
                           where c.Season == "冬季"
                           select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                 coat = from c in db.Coat
                           where c.Season == "春季" || c.Season == "秋季"
                           select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                 coat = from c in db.Coat
                           where c.Season == "春季" || c.Season == "夏季"
                           select c;
            }
            else {
                 coat = from c in db.Coat
                           where c.Season == "夏季"
                           select c;
            }
            return coat;
        }
    }
}
