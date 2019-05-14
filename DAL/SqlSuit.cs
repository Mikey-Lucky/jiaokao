using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlSuit : ISuit
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IQueryable<Suit> SuitBySeason(string season)
        {
            var suit = from s in db.Suit
                        where s.Season == season
                        select s;
            return suit;
        }
    }
}
