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
    }
}
