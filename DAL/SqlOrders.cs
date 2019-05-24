using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

using System.Data.Entity;
using IDAL;

namespace DAL
{
    public class SqlOrders:IOrders
    {
        yichuEntities db = new yichuEntities();
        public IEnumerable<Orders> GetOrders()
        {
            var orders = db.Orders.ToList();
            return orders;
        }
        public IEnumerable<Orders> GetOrdersById(int? id)
        {
            var orders = db.Orders.Where(u=>u.UserID==id);
            return orders;
        }
        public void Order(DateTime datetime, int totalamount,int userid, string uname, string tel,string address)
        {
            //DateTime datetime, int totalamount,
            //db.Cart_Orders(userid,uname,tel,address);
            //db.SaveChanges();
            //int i = db.Orders(uid, uname, userphone, address, note);
            //db.SaveChanges();
            //var orders=db.Orders.Where(o => o.UserID == userid && o.UserName == uname && o.Tel == tel && o.AddressID == addressid && o.TotalAmount==totalamount&&o.OrderTime==datetime).FirstOrDefault();
            //db.Orders.Add(orders);
            //db.SaveChanges();
            var order = new Orders()
            {
                OrderTime = datetime,
                TotalAmount = totalamount,
                UserID = userid,
                UserName = uname,
                Tel = tel,
                Address = address
            };
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public void RemoveOrders(Orders orders)
        {
            db.Orders.Remove(orders);
            db.SaveChanges();
        }
        public void EditOrders(Orders orders)
        {
            db.Entry(orders).State = EntityState.Modified;
            db.SaveChanges();
        }
        //下单
        //此处id为CartID
        public Cart Pay(int? id, int userid,string uname,string tel,string address)
        {
            //将选中订单的flag设置为1          
            //var cart = db.Cart.Where(c => c.CartID == id).FirstOrDefault();
            //cart.Flag = 1;
            //var r = db.Cart.Where(s=>s.CartID==id);
           
            //int id = Convert.ToInt32(Session["User_id"]);
            ////int Flag = 0;
            //var nowtime = System.DateTime.Now;
            //var t = Convert.ToDouble(cartmanager.getgoodsbyid(GoodsID).Unitprice);
            //var amount = cartmanager.getgoodsbyid(GoodsID).TotalStorageAmount;
            ////var price = t;
            //var Count = Convert.ToInt32(Request.Form["number"]);
            var p = db.Cart.Where(t => t.CartID == 6).FirstOrDefault();
            
            var a = p.CartTime;
            var b = p.Count;
            var c = p.Price;
            var d = p.GoodsID;
            var e = p.UserID;
            
            db.Cart.Remove(p);
            var s = new Cart()
            {
                CartTime = a,
                Count = b,
                Price = c,
                GoodsID = d,
                UserID = e,
                Flag = 1
            };
            db.Cart.Add(s);
            db.SaveChanges();
            db.Cart_Orders(userid, uname, tel, address);
            db.SaveChanges();
            return s;
        }
    }
}
