using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlCart:ICart
    {
       
            yichuEntities db = DbContextFactory.CreateDbContext();
            public IEnumerable<Cart> Cart(int? id)
            {
                var cart = from o in db.Cart
                           where o.UserID == id
                           select o;
                return cart;

            }
            public void Delete(int CartID)
            {
                var cart = db.Cart.Where(o => o.CartID == CartID).FirstOrDefault();
                db.Cart.Remove(cart);
                db.SaveChanges();
            }
        //public void DirectBuy(int GoodsID, DateTime time, int ID, int num)
        //{
        //    var Books = db.Goods.Where(o => o.GoodsID == GoodsID).FirstOrDefault();
        //    Books.Amount = Books.Amount - num;
        //    db.SaveChanges();

        //    var orders = db.Orders.Where(o => o.UserID == ID);

        //    foreach (var i in orders)
        //    {
        //        DateTime c = Convert.ToDateTime(i.OrderTime);
        //        if (String.Compare(c.Ticks.ToString(), time.Ticks.ToString()) == 0)
        //        {
        //            var OrderID = i.OrderID;
        //            var orderdetails = new OrderDetails()
        //            {
        //                GoodsID = GoodsID,
        //                Count = num,
        //                UserID = ID,
        //                OrderID = OrderID
        //            };
        //            db.OrderDetails.Add(orderdetails);
        //        }
        //    }
        //    db.SaveChanges();
        //}
      
            public void Update(int num, int CartID)
            {
                var cart = db.Cart.Where(o => o.CartID == CartID).FirstOrDefault();
                cart.Count = num;
                               
                db.SaveChanges();
            }
        public void AddCart(int userid, int goodsid, int count, DateTime carttime, double price, int flag)
        {
            var ca =db.Cart.Where(o => o.GoodsID == goodsid).FirstOrDefault();
            if (ca == null)
            { 
                var cart = new Cart()
                {
                    UserID = userid,
                    GoodsID = goodsid,
                    Count = count,
                    CartTime = carttime,
                    Price = price,
                    Flag = flag
                };
                db.Cart.Add(cart);
                db.SaveChanges();
            }
            else
            {
                ca.Count = ca.Count + count;
                db.SaveChanges();
            }
        }
        public Goods getgoodsbyid(int? id)
        {
            var gd = db.Goods.Where(u => u.GoodsID == id).FirstOrDefault();
            return gd;
        }
        public Cart getcartbyid(int? id)
        {
            var ct = db.Cart.Where(u => u.CartID == id).FirstOrDefault();
            return ct;
        }
        //public int GetCartIidByDatetime(DateTime datetime)
        //{
        //     var t=db.Cart.Where(c=>c.CartTime==datetime).FirstOrDefault();
        //    return t.CartID;

        //}
        public Cart whereCartById(int uid, int gid)
        {
           Cart shopcar = db.Cart.Where(c => c.UserID == uid)
                .Where(c => c.GoodsID == gid).FirstOrDefault();
            return shopcar;
        }
        //推荐，根据购物车中的衣服款式推荐
        public IEnumerable<Goods>  getgoodsbycart(int userid)
        {
            //var goods = from o in db.Goods
              //          select o;
            var goods= (IEnumerable < Goods > )db.Cart_Goods(userid);
            return goods;

        }
    }
}
