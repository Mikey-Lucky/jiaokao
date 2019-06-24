using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using 精致的衣橱.Models;
using 精致的衣橱.Attributes;
using System.Data.SqlClient;

namespace 精致的衣橱.Controllers
{
    public class RecommendController : Controller
    {
        yichuEntities db = new yichuEntities();
        // GET: Recommend
        CartManager cartmanager = new CartManager();
        GoodsManager goodsmanager = new GoodsManager();
        //根据购物车中的东西推荐
        //根据订单明细中的东西推荐
        [Login]
        public ActionResult RecomGoods()
        {
            //int userid =6;
            int userid = Convert.ToInt32(Session["User_id"]);
            var cart = db.Cart.Where(u => u.UserID == userid).FirstOrDefault();
            var orderdetails = db.OrderDetails.Where(u => u.UserID == userid).FirstOrDefault();
            if (cart != null)
            {
                SqlParameter id = new SqlParameter("@userid", userid);
                IEnumerable<Goods> goods1 = db.Database.SqlQuery<Goods>("exec [Cart_Goods] @userid", id).Cast<Goods>().ToList();
                db.SaveChanges();
                return View(goods1);
            }

            else if (orderdetails != null)
            {

                SqlParameter id = new SqlParameter("@userid", userid);
                IEnumerable<Goods> goods1 = db.Database.SqlQuery<Goods>("exec [OrderDetails_Goods] @userid", id).Cast<Goods>().ToList();
                db.SaveChanges();
                return View(goods1);
            }
            else 
            {
                var s1 = from c in db.Cart


                         select c;
                var s2 = from o in db.OrderDetails
                         select o;


                foreach (var i in s2)
                {
                    var goods = goodsmanager.GetNewGoods(20);
                    if (userid != i.UserID)


                        return View(goods);


                }
                var goods2 = goodsmanager.GetNewGoods(20);
                return View(goods2);

            }

                
        }
        //获取最新上架的意见商品
        public ActionResult todaygoods()
        {
            //var newgoods = from g in db.Goods
            //               orderby g.ShangjiaTime ascending
            //               select g;
            var goods = db.Goods.OrderByDescending(t => t.ShangjiaTime).Take(1);
            return PartialView(goods);


        }
    }
}