using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

using System.Data.Entity;
using IDAL;
using Models;

namespace DAL
{
    public class SqlOrderDetails:IOrderDetails
    {
        yichuEntities db = new yichuEntities();

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
                    //var o = new OrderDetails()
                    //{
                    //    GoodsID = GoodsID,
                    //    Count = Num,
                    //    UserID = ID,
                    //    OrderID = orderid
                    //};


                    //db.OrderDetails.Add(o);

                    db.SaveChanges();
                }
            }
           
        }


        
    }
}
