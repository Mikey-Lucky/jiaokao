using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
     public class SqlGGCC:IGGCC
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<GGCC> GetGoods()
        {
            var goods = db.GGCC.ToList();
            return goods;
        }
        public IEnumerable<GGCC> Category()
        {
            var cate = (from o in db.GGCC
                       select o).ToList();
            return cate;
        }
        public IEnumerable<GGCC> GetCategoryByCateName(string season, string sex, string style, string material, string color)
        {
            var categorygoods = from o in db.GGCC
                                where o.Color == color && o.Season == season && o.Sex == sex && o.Style == style && o.Material == material
                                select o;
            return categorygoods;
        }
    }
}
