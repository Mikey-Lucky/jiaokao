using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using 精致的衣橱.Models;
using 精致的衣橱.Attributes;

namespace 精致的衣橱.Controllers
{
    public class RecommendController : Controller
    {
        yichuEntities db = new yichuEntities();
        // GET: Recommend
        CartManager cartmanager = new CartManager();
        //根据购物车中的东西推荐
        //[Login]
        public ActionResult Index1()
        {
            int userid = 1;
            var cart = db.Cart.Where(u => u.UserID == userid);
            if (cart != null)
            {
                return View(cartmanager.getgoodsbycart(userid));
            }
                
            return View();
        }
    }
}