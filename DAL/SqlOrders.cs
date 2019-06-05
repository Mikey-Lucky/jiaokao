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
        public Cart Pay(int? id, int userid, string uname, string tel, string address)
        {
            var cart = db.Cart.FirstOrDefault(p => p.CartID == id);
            if (id!=null)
            { 
            //获取CartID=id的详情
            
            cart.Flag = 1;
            //db.Cart.Add(s);
            db.SaveChanges();
            }
            //db.Cart_Orders(userid, uname, tel, address);
                             
            return cart;

        }
        


    }
}
