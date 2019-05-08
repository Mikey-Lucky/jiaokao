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
        public IEnumerable<Goods> GetHotGoods(int top)
        {
            var hotgoods = from good in db.Goods
                           orderby good.Amount ascending
                           select good;
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
