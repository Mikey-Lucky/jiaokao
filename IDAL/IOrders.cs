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
        void Order(int userid, string uname, string tel, string address);
    }
}
