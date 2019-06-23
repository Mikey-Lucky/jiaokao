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
    public class SqlGoods : IGoods
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Goods> GetHotGoods(int top)
        {
            var hotgoods = from good in db.Goods
                           orderby good.Amount descending
                           select good;
            return hotgoods.Take(top);
            //var hotgoods = from o in db.Goods_Color
            //               join b in db.Goods on o.GoodsID equals b.GoodsID
            //               orderby b.Amount
            //               select o;
            //return hotgoods.Take(top);
        }

        public IEnumerable<Goods> GetNewGoods(int top)
        {
            var newgoods = from g in db.Goods
                           orderby g.ShangjiaTime ascending
                           select g;
            return newgoods.Take(top);
        }
        public IEnumerable<Goods> ChunQiu(int top)
        {

            var goods = db.Goods.Where(o => o.Season == "春").Take(top);
            return goods;
        }
        public IEnumerable<Goods> Xia(int top)
        {
            var goods = db.Goods.Where(u => u.Season == "夏").Take(top);
            return goods;
        }
        public IEnumerable<Goods> Dong(int top)
        {
            var goods = db.Goods.Where(u => u.Season == "冬").Take(top);
            return goods;
        }
        public IEnumerable<Goods> Getsall()
        {
            var goods = db.Goods.ToList();
            return goods;
        }
       public IEnumerable<Goods> Category(string sex,string season,string material,string style,string type)
        {
            var goods = db.Goods.Where(u => u.Sex == sex && u.Season==season && u.Material==material && u.Style==style && u.Type==type);
            return goods;
        }
        public IEnumerable<Goods> Search(string search)
        {
            var t = from p in db.Goods
                    where p.Name.Contains(search) || p.Season.Contains(search) || p.Sex.Contains(search) || p.Style.Contains(search) || p.Type.Contains(search) || p.Material.Contains(search)
                    select p;
            return t.ToList();
        }
        public void AddGoods(Goods goods)
        {
            db.Goods.Add(goods);
            db.SaveChanges();
        }
        public void DeleteGoods(Goods goods)
        {
            db.Goods.Remove(goods);
            db.SaveChanges();
        }
        public void EditGoods(Goods goods)
        {
            db.Entry(goods).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
