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

        public void AddSuit(Suit suit)
        {
            db.Suit.Add(suit);
            db.SaveChanges();
        }

        public void DeleteSuitById(int id)
        {
            Suit suit = db.Suit.Where(s => s.SuitID == id).FirstOrDefault();
            if (suit != null)
            {
                db.Suit.Remove(suit);
            }
            db.SaveChanges();
        }

        public IQueryable<Suit> SuitBySeason(string season,int userid)
        {
            var suit = from s in db.Suit
                        where s.Season == season&&s.Wardrobe.Userid==userid
                        select s;
            return suit;
        }
        public IQueryable<Suit> SuitByTemp(int temp,int userid)
        {
            IQueryable<Suit> suit;
            if (temp < 5)
            {
                suit = from c in db.Suit
                        where c.Season == "冬季" && c.Wardrobe.Userid == userid
                       select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                suit = from c in db.Suit
                        where (c.Season == "春季" || c.Season == "秋季") && c.Wardrobe.Userid == userid
                       select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                suit = from c in db.Suit
                        where (c.Season == "春季" || c.Season == "夏季") && c.Wardrobe.Userid == userid
                       select c;
            }
            else
            {
                suit = from c in db.Suit
                        where c.Season == "夏季" && c.Wardrobe.Userid == userid
                       select c;
            }
            return suit;

        }
    }
}
