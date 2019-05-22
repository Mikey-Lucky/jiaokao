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
            var orderss = db.Orders.ToList();
            return orderss;
        }
        public Orders GetOrdersById(int? id)
        {
            Orders orders = db.Orders.Find(id);
            return orders;
        }
        public void Buy(DateTime datetime, int totalamount, int userid, string uname, string tel, int addressid)
        {
            //int i = db.Orders(uid, uname, userphone, address, note);
            //db.SaveChanges();
            var orders=db.Orders.Where(o => o.UserID == userid && o.UserName == uname && o.Tel == tel && o.AddressID == addressid).FirstOrDefault();
            db.Orders.Add(orders);
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
    }
}
