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
        
        public IEnumerable<Models.OrderDetails> GetOrderdetailsById(int? orderid)
        {
            var t = from o in db.OrderDetails
                    where o.OrderID == orderid
                    select o;
            return t;
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
                if (String.Compare(t.ToString(), dateTime.Ticks.ToString()) == 0)
                {
                    var OrderID = i.OrderID;
                    var orderdetails = new Models.OrderDetails()
                    {
                        GoodsID = GoodsID,
                        Count = Num,
                        UserID = ID,
                        OrderID=OrderID
                    };
                    db.OrderDetails.Add(orderdetails);
                }
            }
            db.SaveChanges();
        }
    }
}
