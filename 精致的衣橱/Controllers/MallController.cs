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
        OdersManager odersmanager = new OdersManager();
        AddressManager addressmanager = new AddressManager();
        OrderDetailsManager orderdetailsmanager = new OrderDetailsManager();
        GoodsLikeManager goodslikemanager = new GoodsLikeManager();
        GoodsCommentManager goodscommentmanager = new GoodsCommentManager();
        ComReplyManager comreplymanager = new ComReplyManager();
        public ActionResult Index()
        {
            var g1 = goodsmanager.GetHotGoods(8);
            var g2 = goodsmanager.GetNewGoods(10);
            var g3 = goodsmanager.ChunQiu(8);
            var g4 = goodsmanager.Xia(8);
            var g5 = goodsmanager.Dong(8);
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
            Session["goodsid"] = id;
            var a = db.Goods.Where(p => p.GoodsID == id).FirstOrDefault();
            var ScanNum = Convert.ToInt32(Request["ScanNam"]);
            a.Pageview = ScanNum;
            db.SaveChanges();
            
            Session["ScanNum"] = ScanNum;
            return View(a);

        }
       
        public ActionResult Category(string sex, string season, string material, string style, string type,string currentFilter1,string currentFilter2, string currentFilter3, string currentFilter4, string currentFilter5,int? page)
        {
            var c1 = goodsmanager.Getsall();
            if(sex!=null || season !=null || material!=null || style!=null || type!=null)
            {
                page = 1;
              
            }
            if (sex != null && season != null && material != null && style != null && type != null)
            {
                sex = currentFilter1;
                ViewBag.Currentfilter1 = sex;
                season = currentFilter2;
                ViewBag.Currentfilter2 = season;
                material = currentFilter3;
                ViewBag.Currentfilter3 = material;
                style = currentFilter4;
                ViewBag.Currentfilter4 = style;
                type = currentFilter5;
                ViewBag.Currentfilter5 = type;
            }
            if(sex!=null && season!=null && material!=null && season!=null && type!=null)
            {
                c1 = c1.Where(x => x.Sex == sex && x.Season == season && x.Material == material && x.Style == style && x.Type == type);
            }
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(c1.ToPagedList(pageNumber, pageSize));


        }
        public ActionResult Search()
        {
            var sear = Request["search"].ToString();
            var seagoods = goodsmanager.Search(sear);
            
            if (seagoods != null)
            {
                //int pageSize = 12;
                //int pageNum = (page ?? 1);
                //return PartialView(seagoods.ToPagedList(pageNum, pageSize));
                return PartialView(seagoods);
            }
            
            else
                return Content("您查找的商品不存在");
            
        }
        //[Login]
        public ActionResult Cart()
        {
            //var userid = Convert.ToInt32(Session["User_id"]);
            int userid = 1;
            var cart = cartmanager.Cart(userid);
            return View(cart);
        }
        //[Login]
        [HttpPost]
        //public ActionResult jrgwc([Bind(Include = "UserID,GoodsID,Count,CartTime,Price,Flag")]Cart cart)
        public ActionResult Cart(int GoodsID, Cart cart)
        {

            //int id = Convert.ToInt32(Session["User_id"]);
            int id = 1;
            //int Flag = 0;
            var nowtime = System.DateTime.Now;
            var t = Convert.ToDouble(cartmanager.getgoodsbyid(GoodsID).Unitprice);
            var amount = cartmanager.getgoodsbyid(GoodsID).TotalStorageAmount;
            //var price = t;
            var Count = Convert.ToInt32(Request["number"]);
            if (amount > Count)
            {
                int Flag = 0;
                cartmanager.AddCart(id, GoodsID, Count, nowtime, t, Flag);
                return Content("<script>alert('加入购物车成功');window.location.href='../Mall/Cart';</script>");
            }
            else
            {
                return Content("<script>alert('加入购物车失败')</script>");
            }
        }

        //[Login]
        public ActionResult UpdateCartNum(int num, int CartID)
        {
            
            cartmanager.Update(num, CartID);
            return Content("<script>alert('更新成功');window.location.href='../Mall/Cart';</script>");
        }

        //[Login]
        public ActionResult Delete(int CartID)
        {
           
            cartmanager.Delete(CartID);
            return Content("<script>alert('删除成功');window.location.href='../Mall/Cart';</script>");

        }
        
        //商品评论回复
        public ActionResult Comment(int goodsid)
        {
            goodsid = Convert.ToInt32(Session["goodsid"]);
            var com = goodscommentmanager.Getgoodscommentbyid(goodsid);
            return View(com);
        }
        [HttpPost]
        //[Login]
        public ActionResult Comment(int goodsid,string text)
        {
            //goodsid =2;
            //var text;
            //goodsid = Convert.ToInt32(Session["goodsid"]);
            DateTime datetime = System.DateTime.Now;
            int thumb = 0;
            //int id = Convert.ToInt32(Session["User_id"]);
            int id = 1;
            if (ModelState.IsValid)
            {
                if (text != null)
                {

                    goodscommentmanager.AddGoodsComment(text,id,goodsid,datetime,thumb);
                    
                }
                //else
                //{
                //    return Content("<script>alert('评论不能为空！');history.go(-1)</script>");
                //}
                //return View();
            }
            return Content("<script>alert('评论成功！')/*;history.go(0)*/</script>");
            //return View();

        }
        public ActionResult Reply(int commentid)
        {
            var rep = comreplymanager.Reply(commentid);
            return View(rep);
        }
        [HttpPost]
        public ActionResult Reply(int commentid,string text)
        {
            int userid = 1;
            var datetime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                if (text != null)
                {
                    comreplymanager.AddComReply(userid, commentid, text, datetime);
                }
                else
                    return Content("回复不能为空");
            }
            return View();

        }
        //[Login]
        public ActionResult Order()
        {
            //int id = Convert.ToInt32(Session["User_id"]);
            int id = 1;
            var order = odersmanager.GetOrdersById(id);
            return View(order);
        }
       
        [HttpPost]
        //[Login]
        public ActionResult Addaddress(string add)
        {
            //int userid = Convert.ToInt32(Session["User_id"]);
            int userid = 1;
            add = Request["dizhi"].ToString();

            addressmanager.Add(userid, add);
            return Content("<script>alert('添加成功');window.location.href='../Mall/Order';<script>");

        }
        //将Buy改成了Order
        [HttpPost]
        //[Login]
        public ActionResult Buy(int[] a, string name, string userphone, string address, int total)
        {
            var datetime = System.DateTime.Now;
            //int uid = Convert.ToInt32(Session["User_id"]);
            int uid = 1;
            //odersmanager.Order(datetime, total, uid, name, userphone, address);
            for (int i = 0; i < a.Length; i++)
            {
                odersmanager.Pay(a[i], uid, name, userphone, address);
            }
            //利用存储过程Cart_Orders实现
            db.Cart_Orders(uid, name, userphone, address);

            Message msg = new Message()
            {
                message = "下单成功"
            };
            return base.Json(msg);
        }
        [HttpPost]
        //[Login]
        public ActionResult DirectBuy(int total,string uname,string tel,string address,int num,int goodsid)
        {
             
            var datetime = System.DateTime.Now;
            //int uid = Convert.ToInt32(Session["User_id"]);
            int uid = 1;
            odersmanager.Order(datetime, total, uid, uname, tel, address);
            orderdetailsmanager.DirectBuy(goodsid, datetime, uid, num);
            Message msg = new Message()
            {
                message = "下单成功"
            };
            return base.Json(msg);


        }
        //[Login]
        public ActionResult OrderDetails1(int? orderid)
        {

            var t = orderdetailsmanager.OrderDetails(orderid);
            
            
            return View(t);
        }
        //点赞
        //[Login]
        public int Zan(int goodsid)
        {

            //int userid = Convert.ToInt32(Session["User_id"]);
            int userid = 2;
           
            goodslikemanager.GoodsLikeClick(userid,goodsid);
            int num = goodslikemanager.goodslikenum(goodsid);
            return num;
        }

    }
}

