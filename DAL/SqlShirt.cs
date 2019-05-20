using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using System.Data.Entity;

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

        public IQueryable<Shirt> ShirtByTemp(int temp)
        {
            IQueryable<Shirt> shirt;
            if (temp < 5)
            {
                shirt = from c in db.Shirt
                        where c.Season == "冬季"
                       select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                shirt = from c in db.Shirt
                        where c.Season == "春季" || c.Season == "秋季"
                       select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                shirt = from c in db.Shirt
                        where c.Season == "春季" || c.Season == "夏季"
                       select c;
            }
            else
            {
                shirt = from c in db.Shirt
                        where c.Season == "夏季"
                       select c;
            }
            return shirt;
        }
        public void AddShirt(Shirt shirt)
        {
            db.Shirt.Add(shirt);
            db.SaveChanges();
        }
        public Shirt GetShirtById(int id)
        {
            var shirt = from s in db.Shirt
                        where s.ShirtID ==id
                        select s;
            return shirt.FirstOrDefault();  
        }   
        public void DeleteShirtById(int id)
        {
            Shirt shirt = db.Shirt.Where(s => s.ShirtID == id).FirstOrDefault();
            IQueryable<Coordinate> co = db.Coordinate.Where(c => c.ShirtID == id);
            if (shirt != null) {
                db.Shirt.Remove(shirt);
                db.Coordinate.RemoveRange(co);//相关的搭配表数据删除
            }
            db.SaveChanges();
        }

        public void UpdateShirt(Shirt shirt)
        {

            db.Entry(shirt).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
