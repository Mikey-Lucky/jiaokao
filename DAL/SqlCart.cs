using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlCart:ICart
    {
       
            yichuEntities db = DbContextFactory.CreateDbContext();
            public IEnumerable<Cart> Cart(int? id)
            {
                var cart = from o in db.Cart
                           where o.UserID == id
                           select o;
                return cart;

            }
            public void Delete(int CartID)
            {
                var cart = db.Cart.Where(o => o.CartID == CartID).FirstOrDefault();
                db.Cart.Remove(cart);
                db.SaveChanges();
            }
            public void DirectBuy(int GoodsID, DateTime time, int ID, int num)
            {
                var Books = db.Goods.Where(o => o.GoodsID == GoodsID).FirstOrDefault();
                Books.Amount = Books.Amount - num;
                db.SaveChanges();
                var orders = db.Orders.Where(o => o.UserID == ID);

                foreach (var i in orders)
                {
                    DateTime c = Convert.ToDateTime(i.OrderTime);
                    if (String.Compare(c.Ticks.ToString(), time.Ticks.ToString()) == 0)
                    {
                        var OrderID = i.OrderID;
                        var orderdetails = new OrderDetails()
                        {
                            GoodsID = GoodsID,
                            Count = num,
                            UserID = ID,
                            OrderID = OrderID
                        };
                        db.OrderDetails.Add(orderdetails);
                    }
                }
                db.SaveChanges();
            }
            public Cart Pay(int? id, DateTime dateTime, int ID)
            {
                //将选中订单的flag设置为1          
                var cars = db.Cart.FirstOrDefault(o => o.CartID == id);
                cars.Flag = 1;
                db.SaveChanges();
                //获取书 ID  并修改库存
                var goodsid = cars.GoodsID;
                var goods = db.Goods.Where(o => o.GoodsID == goodsid).FirstOrDefault();
                goods.TotalStorageAmount= goods.TotalStorageAmount - cars.Count;
                db.SaveChanges();
                //添加进订单详情         
                var orders = db.Orders.Where(o => o.UserID == ID);
                foreach (var i in orders)
                {
                    DateTime c = Convert.ToDateTime(i.OrderTime);
                    if (String.Compare(c.Ticks.ToString(), dateTime.Ticks.ToString()) == 0)
                    {
                        var OrderID = i.OrderID;
                        var orderdetails = new OrderDetails()
                        {
                            GoodsID = cars.GoodsID,
                            Count = cars.Count,
                            UserID = cars.UserID,
                            OrderID = OrderID
                        };
                        db.OrderDetails.Add(orderdetails);

                    }
                }
                db.SaveChanges();
                //未将对象设置引用到实例,时间比较有问题  linq不支持trick,tostring....
                #region
                //var Datetime = dateTime.ToString();
                //var Or = db.Orders.Where(o => o.Time.ToString().CompareTo(Datetime) == 0).FirstOrDefault();
                //var OrderID = Or.OrderID;
                ////var OrderID = (from p in db.Orders
                ////         where p.Time.ToString("yyyy-mm-nn aa:bb:cc").CompareTo(dateTime.ToString("yyyy-mm-nn aa:bb:cc")) == 0 && p.UserID == ID
                ////         select p).FirstOrDefault().OrderID;

                //var orderdetails = new OrderDetails()
                //{
                //    BookID = cars.BookID,
                //    Count = cars.Count,
                //    UserID = cars.UserID,
                //    OrderId = OrderID
                //};
                //db.OrderDetails.Add(orderdetails);
                //db.SaveChanges();
                #endregion
                //删除购物车中的订单
                var carts = db.Cart.Where(o => o.CartID == id && o.Flag == 1).FirstOrDefault();
                db.Cart.Remove(carts);
                db.SaveChanges();
                return cars;
            }
            public void Update(int num, int CartID)
            {
                var cart = db.Cart.Where(o => o.CartID == CartID).FirstOrDefault();
                cart.Count = num;

                db.SaveChanges();
            }
        public void AddCart(int userid, int goodsid, int count, DateTime carttime, double price, int flag)
        {
            var ca =db.Cart.Where(o => o.GoodsID == goodsid).FirstOrDefault();
            if (ca == null)
            { 
                var cart = new Cart()
                {
                    UserID = userid,
                    GoodsID = goodsid,
                    Count = count,
                    CartTime = carttime,
                    Price = price,
                    Flag = flag
                };
                db.Cart.Add(cart);
                db.SaveChanges();
            }
            else
            {
                ca.Count = ca.Count + count;
                db.SaveChanges();
            }
        }
        public Goods getgoodsbyid(int? id)
        {
            var gd = db.Goods.Where(u => u.GoodsID == id).FirstOrDefault();
            return gd;
        }
        public Cart getcartbyid(int? id)
        {
            var ct = db.Cart.Where(u => u.CartID == id).FirstOrDefault();
            return ct;
        }
    }
}
