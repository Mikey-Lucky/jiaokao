using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using 精致的衣橱.Models;
using PagedList;
using 精致的衣橱.Attributes;


namespace 精致的衣橱.Controllers
{
    public class MallController : Controller
    {
        // GET: Mall
        yichuEntities db = new yichuEntities();
        GoodsManager goodsmanager = new GoodsManager();
        GGCCManager ggccmanager = new GGCCManager();
        CartManager cartmanager = new CartManager();
        public ActionResult Index()
        {
            var g1 = goodsmanager.GetHotGoods(8);
            var g2 = goodsmanager.GetNewGoods(10);
            var g3 = goodsmanager.ChunQiu(12);
            var g4 = goodsmanager.Xia(12);
            var g5 = goodsmanager.Dong(12);
            MallViewModel mallviewmodel = new MallViewModel();
            mallviewmodel.HotGoods = g1;
            mallviewmodel.NewGoods = g2;
            mallviewmodel.ChunQiu = g3;
            mallviewmodel.Xia = g4;
            mallviewmodel.Dong = g5;
            return View(mallviewmodel);
        }
        public ActionResult GoodsDetails(int id)
        {
            Session["GoodsID"] = id;
            var a = db.Goods.Where(p => p.GoodsID == id).FirstOrDefault();
            return View(a);
        }
        public ActionResult GoodIndex()
        {
            //var c1 = from o in db.GGCC
            //         where o.Season == season
            //         select o;
            //var c2 = from o in db.GGCC
            //         where o.Sex == sex
            //         select o;
            //var c3 = from o in db.GGCC
            //         where o.Style == style
            //         select o;
            //var c4 = from o in db.GGCC
            //         where o.Material == material
            //         select o;
            //var c5 = from o in db.GGCC
            //         where o.Color == color
            //         select o;
            //Category1ViewModel cate = new Category1ViewModel();
            //cate.Season = c1;
            //cate.Sex = c2;
            //cate.Style = c3;
            //cate.Material = c4;
            //cate.Color = c5;
            //return View(cate);
            var goods = ggccmanager.Category();
            return View(goods);

        }


        //public ActionResult GoodsType(string season,string sex,string style,string material,string color,string currentFilter,int ? page)
        //{
        //    var c1 = ggccmanager.GetGoods();

        //    if(season !=null || sex!=null || style!=null || material!=null || color!=null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        season = currentFilter;
        //        sex = currentFilter;
        //        style = currentFilter;
        //        material = currentFilter;
        //        color = currentFilter;
        //    }
        //    ViewBag.CurrentFilter = season;
        //    ViewBag.CurrentFilter = sex;
        //    ViewBag.CurrentFilter = style;
        //    ViewBag.CurrentFilter = material;
        //    ViewBag.CurrntFilter = color;

        //    if(season!=null||sex!=null||style!=null||material!=null||color!=null)
        //    {
        //        c1 = ggccmanager.GetCategoryByCateName(season,sex,style,material,color);
        //    }
        //    int pageSize = 8;
        //    int pageNumber = (page??1);
        //    return PartialView(c1.ToPagedList(pageNumber,pageSize));
        //}
        //有问题
        public ActionResult GoodsType(string CategoryName, string Season, string currentFilter,int? page)
        {
            var c1 = ggccmanager.GetGoods();
            if (CategoryName != null || Season != null)
            {

                page = 1;
            }
            if (CategoryName != null && Season == null)
            {
                CategoryName = currentFilter;

                ViewBag.CurrentFilter = CategoryName;

            }
            else if (CategoryName == null && Season != null )
            {
                Season = currentFilter;
                ViewBag.CurrentFilter = Season;
            }
                       
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return PartialView(c1.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GoodsShow(string CateName, string season)
        {
            var goods = ggccmanager.GetGoods();
            goods = ggccmanager.GetCategoryByCateName(CateName, season);
            return View(goods);
        }
        [Login]
        public ActionResult Cart()
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            var cart = cartmanager.Cart(userid);
            return View(cart);
        }
        [Login]
        [HttpPost]
        //public ActionResult jrgwc([Bind(Include = "UserID,GoodsID,Count,CartTime,Price,Flag")]Cart cart)
        public ActionResult Cart( int GoodsID,Cart cart)
        {
            //if (Session["Users_id"] != null)
            //{
            //string name = Request.Form["ljgm"];
            int id = Convert.ToInt32(Session["User_id"]);
            
            var nowtime = System.DateTime.Now;
            var t = Convert.ToDouble(cartmanager.getgoodsbyid(GoodsID).Unitprice);
            var amount = cartmanager.getgoodsbyid(GoodsID).TotalStorageAmount;
            //var price = t;
            var Count = Convert.ToInt32(Request.Form["number"]);
            if (amount>Count)
            {
                int Flag = 1;
                cartmanager.AddCart(id, GoodsID, Count, nowtime, t, Flag);
                return Content("<script>alert('加入购物车成功');window.location.href='../Mall/Cart';</script>");
            }
            else
            {
                return Content("<script>alert('加入购物车失败')</script>");
            }
        }
        //更新购物车数量
        [Login]
        public ActionResult UpdateCartNum(int num,int CartID)
        {
            
            cartmanager.Update(num,CartID);
            return Content("<script>alert('更新成功');window.location.href='../Mall/Cart';</script>");
        }

        [Login]
        public ActionResult Delete(int CartID)
        {
            //var ca = db.Cart.Where(u => u.UserID == Convert.ToInt32(Session["User_id"]));
            //var ca = cartmanager.getcartbyid(CartID).CartID;
            cartmanager.Delete(CartID);
            return Content("删除成功");
            
        }
        public ActionResult Comment()
        {
            return View();
        }
    }
}