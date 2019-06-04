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
    public class CartManager
    {
        ICart icart = DataAccess.CreateCart1();
        public IEnumerable<Cart> Cart(int? id)
        {
            //var cart = icart.Cart(int ? id);
            //return cart;
            var cart = icart.Cart(id);
            return cart;
        }
        public void Delete(int CartID)
        {
           icart.Delete(CartID);
        }
        //public void DirectBuy(int GoodsID, DateTime time, int ID, int num)
        //{
        //    icart.DirectBuy(GoodsID,time,ID,num);
        //}
        public void Update(int num, int CartID)
        {
            icart.Update(num,CartID);
        }
        //public Cart Pay(int? id, DateTime datetime, int ID)
        //{
        //    var pay = icart.Pay(id,datetime,ID);
        //    return pay;
        //}
        public void AddCart(int userid, int goodsid, int count, DateTime carttime, double price, int flag)
        {
            icart.AddCart(userid,goodsid,count,carttime,price,flag);
        }
        public Goods getgoodsbyid(int? id)
        {
            var gd=icart.getgoodsbyid(id);
            return gd;
        }
        public Cart getcartbyid(int? id)
        {
            var ct = icart.getcartbyid(id);
            return ct;
        }
        public Cart whereCartById(int uid, int gid)
        {
            var ct = icart.whereCartById(uid,gid);
            return ct;
        }
        //根据购物车有的东西推荐
        public IEnumerable<Goods> getgoodsbycart(int userid)
        
        {
            return icart.getgoodsbycart(userid);
            
        }
    }
}
