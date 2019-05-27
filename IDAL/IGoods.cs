using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IGoods
    {
        //查找销量前几的商品
        IEnumerable<Goods> GetHotGoods(int top);
        //查找最新上架商品
        IEnumerable<Goods> GetNewGoods(int top);
        IEnumerable<Goods> ChunQiu(int top);
        IEnumerable<Goods> Xia(int top);
        IEnumerable<Goods> Dong(int top);
        //IEnumerable<> allgoodsbytype(string sex,string material, string style);
        //void getThumbnum(int goodsid, int userid);
    }
}
