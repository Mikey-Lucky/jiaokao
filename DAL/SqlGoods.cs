using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlGoods : IGoods
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Goods_Color> GetHotGoods(int top)
        {
            //var hotgoods = from good in db.Goods
            //               orderby good.Amount ascending
            //               select good;
            //return hotgoods.Take(top);
            var hotgoods = from o in db.Goods_Color
                           join b in db.Goods on o.GoodsID equals b.GoodsID
                           orderby b.Amount
                           select o;
            return hotgoods.Take(top);
        }

        public IEnumerable<Goods> GetNewGoods(int top)
        {
            var newgoods = from g in db.Goods
                           orderby g.ShangjiaTime ascending
                           select g;
            return newgoods.Take(top);
        }
    }
}
