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
            var goods = igoods.ChunQiu(top);
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
        public IEnumerable<Goods> Getsall()
        {
            var goods = igoods.Getsall();
            return goods;
        }
        public IEnumerable<Goods> Category(string sex, string season, string material, string style, string type)
        {
            var goods = igoods.Category(sex,season,material,style,type);
            return goods;
        }
        public IEnumerable<Goods> Search(string search)
        {
            var goods = igoods.Search(search);
            return goods;
        }
        public void AddGoods(Goods goods)
        {
             igoods.AddGoods(goods);
        }
        public void DeleteGoods(Goods goods)
        {
            igoods.DeleteGoods(goods);
        }
        public void EditGoods(Goods goods)
        {
            igoods.EditGoods(goods);
        }
    }
}
