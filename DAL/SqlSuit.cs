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
        public IQueryable<Suit> SuitByTemp(int temp)
        {
            IQueryable<Suit> suit;
            if (temp < 5)
            {
                suit = from c in db.Suit
                        where c.Season == "冬季"
                        select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                suit = from c in db.Suit
                        where c.Season == "春季" || c.Season == "秋季"
                        select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                suit = from c in db.Suit
                        where c.Season == "春季" || c.Season == "夏季"
                        select c;
            }
            else
            {
                suit = from c in db.Suit
                        where c.Season == "夏季"
                        select c;
            }
            return suit;

        }
    }
}
