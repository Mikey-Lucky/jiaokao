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
        public Orders GetOrdersById(int? id)
        {
            Orders orders = iorders.GetOrdersById(id);
            return orders;
        }

        public void Buy(DateTime datetime, int totalamount, int userid, string uname, string tel, int addressid)
        {
            iorders.Buy(datetime,totalamount,userid, uname, tel, addressid);
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
