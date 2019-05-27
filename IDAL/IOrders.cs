using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IOrders
    {
        IEnumerable<Orders> GetOrders();
        IEnumerable<Orders> GetOrdersById(int? id);
        void RemoveOrders(Orders orders);
        void EditOrders(Orders orders);
        void Order(DateTime datetime, int totalamount, int userid, string uname, string tel, string address);
       Cart Pay(int? id, int userid, string uname, string tel, string address);
        //void getOrderDetails(OrderDetails orderdetails);
       
    }
}
