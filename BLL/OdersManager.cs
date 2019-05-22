using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;
namespace BLL
{
    public class OdersManager
    {
        IOrders iorders = DataAccess.CreateOrders();
        public IEnumerable<Orders> GetOrders()
        {
            var orderss = iorders.GetOrders();
            return orderss;
        }
        public IEnumerable<Orders> GetOrdersById(int? id)
        {
            var orders = iorders.GetOrdersById(id);
            return orders;
        }

        public void Order(DateTime datetime, int totalamount, int userid, string uname, string tel, int addressid)
        {
            iorders.Order(datetime,totalamount,userid, uname, tel, addressid);
        }
        public void RemoveOrders(Orders orders)
        {
            iorders.RemoveOrders(orders);

        }
        public void EditOrders(Orders orders)
        {
            iorders.EditOrders(orders);

        }
    }
}
