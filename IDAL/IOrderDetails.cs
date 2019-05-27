using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL
{
    public interface IOrderDetails
    {
        IEnumerable<OrderDetails> OrderDetails(int? id);

        void DirectBuy(int GoodsID, DateTime dateTime, int ID, int Num);
    }
}
