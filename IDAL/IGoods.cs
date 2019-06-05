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
        IEnumerable<Goods> Getsall();
        IEnumerable<Goods> Category(string sex, string season, string material, string style, string type);
        IEnumerable<Goods> Search(string search);
        void AddGoods(Goods goods);
        void DeleteGoods(Goods goods);
        void EditGoods(Goods goods);
    }
}
