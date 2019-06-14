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
        //[Login]
        public ActionResult RecomGoods()
        {
            int userid = 2;
            var cart = db.Cart.Where(u => u.UserID == userid);
            if(cart !=null)
            { 
                SqlParameter id = new SqlParameter("@userid",userid);
                IEnumerable<Goods> goods = db.Database.SqlQuery<Goods>("exec [Cart_Goods] @userid",id).Cast<Goods>().ToList();
                db.SaveChanges();
                return View(goods);
            }
            var orderdetails = db.OrderDetails.Where(u => u.UserID == userid);
            if (orderdetails != null)
            {
                SqlParameter id = new SqlParameter("@userid",userid);
                IEnumerable<Goods> goods = db.Database.SqlQuery<Goods>("exec [OrderDetails_Goods] @userid", id).Cast<Goods>().ToList();
                db.SaveChanges();
                return View(goods);
            }
            //当购物车和订单明细均为空时，推荐最新上架商品
            if(cart==null && orderdetails == null)
            {
                var goods = goodsmanager.GetNewGoods(20);
                return View(goods);
            }
            //var scannum = Session["ScanNum"];
           
            
            return View();
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