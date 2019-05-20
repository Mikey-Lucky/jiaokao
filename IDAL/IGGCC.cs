using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IGGCC
    {
        IEnumerable<GGCC> GetGoods();
        //Goods GetGoodsById(int? id);
        IEnumerable<GGCC> Category();
        //IEnumerable<GGCC> GetCategoryByCateName(string season,string sex,string style,string material,string color);
        IEnumerable<GGCC> GetCategoryByCateName(string Catename, string season);
    }
}
