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
        Orders GetOrdersById(int? id);
        void RemoveOrders(Orders orders);
        void EditOrders(Orders orders);
        void Buy(DateTime datetime,int totalamount,int userid, string uname, string tel, int addressid);
    }
}
