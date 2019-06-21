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

        public void AddCoat(Coat coat)
        {
            db.Coat.Add(coat);
            db.SaveChanges();
        }

        public IQueryable<Coat> CoatBySeason(string season,int userid)
        {
            var coat = from c in db.Coat
                        where c.Season == season&&c.Wardrobe.Userid==userid
                        select c;
            return coat;
        }

        public IQueryable<Coat> CoatByTemp(int temp,int userid)
        {
            IQueryable<Coat> coat;
            if (temp < 5)
            {
                 coat = from c in db.Coat
                           where c.Season == "冬季" && c.Wardrobe.Userid == userid
                        select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                 coat = from c in db.Coat
                           where (c.Season == "春季" || c.Season == "秋季") && c.Wardrobe.Userid == userid
                        select c;
            }
            else if (temp >= 20 && temp < 24)
            {
                 coat = from c in db.Coat
                           where (c.Season == "春季" || c.Season == "夏季") && c.Wardrobe.Userid == userid
                        select c;
            }
            else {
                 coat = from c in db.Coat
                           where c.Season == "夏季" && c.Wardrobe.Userid == userid
                        select c;
            }
            return coat;
        }

        public void DeleteCoatById(int id)
        {
            Coat coat = db.Coat.Where(s => s.CoatID == id).FirstOrDefault();
            if (coat != null)
            {
                db.Coat.Remove(coat);
            }
            db.SaveChanges();
        }
    }
}
