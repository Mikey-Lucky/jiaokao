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
    public class GoodsManager
    {
        IGoods igoods = DataAccess.CreateGoods();
        //热门商品
        public IEnumerable<Goods> GetHotGoods(int top)
        {
            var hotgoods = igoods.GetHotGoods(top);
            return hotgoods;
        }
        //新品上架
        public IEnumerable<Goods> GetNewGoods(int top)
        {
            var newgoods = igoods.GetNewGoods(top);
            return newgoods;
        }
        public  IEnumerable<Goods> ChunQiu(int top)
        {
            var goods = igoods.Xia(top);
            return goods;
        }
        public IEnumerable<Goods> Xia(int top)
        {
            var goods = igoods.Xia(top);
            return goods;
        }
        public IEnumerable<Goods> Dong(int top)
        {
            var goods = igoods.Dong(top);
            return goods;
        }
    }
}
