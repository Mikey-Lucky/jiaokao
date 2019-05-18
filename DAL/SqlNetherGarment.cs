using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlNetherGarment : INetherGarment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public void AddNether(NetherGarment nether)
        {
            db.NetherGarment.Add(nether);
            db.SaveChanges();
        }

        public IQueryable<NetherGarment> NetherGarmentBySeason(string season)
        {
            var nether = from n in db.NetherGarment
                        where n.Season == season
                        select n;
            return nether;
        }

        public IQueryable<NetherGarment> NetherGarmentByTemp(int temp)
        {
            IQueryable<NetherGarment> nether;
            if (temp < 5)
            {
                nether = from c in db.NetherGarment
                       where c.Season == "冬季"
                       select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                nether = from c in db.NetherGarment
                       where c.Season == "春季" || c.Season == "秋季"
                       select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                nether = from c in db.NetherGarment
                       where c.Season == "春季" || c.Season == "夏季"
                       select c;
            }
            else
            {
                nether = from c in db.NetherGarment
                       where c.Season == "夏季"
                       select c;
            }
            return nether;
        }
    }
}
