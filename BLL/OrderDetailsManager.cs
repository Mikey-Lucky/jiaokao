using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;

namespace BLL
{
   
    public class OrderDetailsManager
    {
        IOrderDetails p = DataAccess.CreateOrderDetails();
        public IEnumerable<Models.OrderDetails> GetOrderdetailsById(int? orderid)
        {
            var orderdetails = p.GetOrderdetailsById(orderid);
            return orderdetails;
        }
        public void DirectBuy(int GoodsID, DateTime dateTime, int ID, int Num)
        {
          p.DirectBuy(GoodsID,dateTime,ID,Num);
        }
    }
}
