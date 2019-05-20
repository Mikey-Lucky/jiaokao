using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlGGCC : IGGCC
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<GGCC> GetGoods()
        {
            var goods = db.GGCC.ToList();
            return goods;
        }
        public IEnumerable<GGCC> Category()
        {
            //var cate = (from o in db.GGCC
            //            select o).ToList().Distinct();
            //var cate1 = db.GGCC.Distinct(p => new { p.Season, p.Color });
            //var cate1 = (from o in db.GGCC
            //            select o).GroupBy(p => p.Season, p => p.Color)
            //          .Select(g => g.First()).ToList();
            var cate = from o in db.GGCC
                       select o;
            //var t = cate.DistinctBy();
            return cate;
        }
        public IEnumerable<GGCC> GetCategoryByCateName(string CateName, string season)
        {
            var categorygoods = from o in db.GGCC
                                where o.Color == CateName || o.Season == season
                                select o;
            return categorygoods;
        }
    }
}

