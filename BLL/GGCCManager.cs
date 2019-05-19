using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class GGCCManager
    {
        IGGCC ig = DataAccess.CreateGGCC();
        public IEnumerable<GGCC> GetGoods()
        {
            var goods = ig.GetGoods();
            return goods;
        }
        public IEnumerable<GGCC> Category()
        {
            var category = ig.Category();
            return category;
        }
        public IEnumerable<GGCC> GetCategoryByCateName(string season, string sex, string style, string material, string color)
        {
            var getcategorybyname = ig.GetCategoryByCateName(season, sex, style, material, color);
            return getcategorybyname;
        }

    }
}
