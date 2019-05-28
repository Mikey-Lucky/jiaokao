using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    public class SqlOrderDetails:IOrderDetails
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public IEnumerable<Models.OrderDetails> OrderDetails(int? id)
        {
            var order = from t in db.OrderDetails
                        where t.OrderID == id
                        select t;
            return order;
        }
       
        public void DirectBuy(int GoodsID, DateTime dateTime, int ID, int Num)
        {
            var Goods = db.Goods.Where(o => o.GoodsID == GoodsID).FirstOrDefault();
            Goods.Amount = Goods.Amount - Num;
            db.SaveChanges();
            var orders = db.Orders.Where(o => o.UserID == ID);
            foreach (var i in orders)
            {
                var t = i.OrderTime;
                if (t==dateTime)
                {
                    //var OrderID = i.OrderID;
                    var order = db.Orders.Where(u => u.OrderTime == dateTime).FirstOrDefault();
                    var orderid = order.OrderID;
                    var orderdetails = new Models.OrderDetails()
                    {
                        GoodsID = GoodsID,
                        Count = Num,
                        UserID = ID,
                        OrderID=orderid
                    };
                    db.OrderDetails.Add(orderdetails);
                    db.SaveChanges();
                }
            }
           
        }


        //public Cart Pay(int? id, int userid, string uname, string tel, string address, DateTime datetime)
        //{
        //    //获取CartID=id的详情
        //    var cart = db.Cart.FirstOrDefault(p => p.CartID == id);
        //    cart.Flag = 1;
        //    //db.Cart.Add(s);
        //    db.SaveChanges();
        //   db.Cart_Orders(userid, uname, tel, address);
        //    //修改添加进\购物车的商品的库存
        //    //var goodsid = cart.GoodsID;
        //    //var goods = db.Goods.Where(p => p.GoodsID == goodsid).FirstOrDefault();
        //    //goods.TotalStorageAmount = goods.TotalStorageAmount - cart.Count;
        //    //db.SaveChanges();
        //    //var orders = db.Orders.Where(p => p.UserID == userid);
        //    //foreach (var item in orders)
        //    //{
                
        //    //    if (item.OrderTime == datetime)
        //    //    {

        //    //        var ods = new OrderDetails()
        //    //        {
        //    //           Models.OrderDetails. =
        //    //        }




        //    //    }
        //    //}
        //    //var oderdetails = new Cart()
        //    //{
        //    //    GoodsID = 
        //    //}
        //    return cart;

        //}
    }
}
