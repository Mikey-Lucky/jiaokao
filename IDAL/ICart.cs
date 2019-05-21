using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ICart
    {
        IEnumerable<Cart> Cart(int? id);
        void Delete(int CartID);
        void DirectBuy(int GoodsID, DateTime time, int ID, int num);
        void Update(int num, int CartID);
        Cart Pay(int? id, DateTime datetime, int ID);
    }
}

