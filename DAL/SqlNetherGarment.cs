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
        public IQueryable<NetherGarment> NetherGarmentBySeason(string season)
        {
            var nether = from n in db.NetherGarment
                        where n.Season == season
                        select n;
            return nether;
        }
    }
}
