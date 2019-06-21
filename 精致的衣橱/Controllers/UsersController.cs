using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Microsoft.AspNet.Identity;
using 精致的衣橱.Models;

namespace 精致的衣橱.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        yichuEntities db = new yichuEntities();
        UsersManager usersmanager = new UsersManager();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public UsersController()
        {
            UsersManager usersmanager = new UsersManager();
        }
        public ActionResult GetImg()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = Verify.CreateValidateGraphic(out code, 4, width, height, fontsize);
            Session["YZM"] = code;
            return File(bytes, @"image/jpeg");
        }


        //检查验证码
        public bool CheckYZM(string num)
        {
            string cnum = Session["YZM"] == null ? "" : Session["YZM"].ToString();

            if (num.ToLower() == cnum.ToLower() && !string.IsNullOrEmpty(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult RegisterLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(string TrueName, string PasswordR, string Tel)
        {
            var c = usersmanager.Register(TrueName, PasswordR, Tel);
            if (c)
            {
                var id = db.Users.Where(m => m.Tel == Tel).FirstOrDefault().UserID;
                return Content("<script>alert('注册成功！请记住您的ID：" + id + "');window.location.href='../Users/RegisteLogin';</script>");
            }
            return Content("<script>alert('您的电话号码已被注册！请重试');history.go(-1);</script>");
        }



        [HttpPost]
        public ActionResult RegisterLogin(int? UserID, string PasswordL, string YZM)
        {
            string data;
            var url = Request.UrlReferrer;
            var a = usersmanager.Login(UserID, PasswordL);
            var b = CheckYZM(YZM);
            if (a && !b)
            {
                data = "验证码输入错误，请重试";
                return Content("<script>alert('" + data + "')</script>");
            }
            else if (a && b )
            {

                Session["User_id"] = UserID;
                Session["User_image"] = db.Users.Where(m => m.UserID == UserID).FirstOrDefault().HeadImage;
                Session["User_Name"] = db.Users.Where(m => m.UserID == UserID).FirstOrDefault().UserName;
                data = "登录成功";
                if(UserID != 8)
                {
                    //return Content("<script>alert('加入购物车成功');window.location.href='../Mall/Cart';</script>");
                    return Content("<script>alert('登陆成功');window.history.go(-2)</script>");
                }
                else
                {
                    return Content("<script>alert('"+data+ "');window.location.href='../Orders/index';</script>");
                }

            }
            else if (!a && b)
            {
                data = "账号或密码错误，请重试";
                //return Content(data);
                return Content("<script>alert('" + data + "')</script>");
            }
            else
                data = "请按照格式输入";
            return Content("<script>alert('" + data + "')</script>");
        }



        //找回密码
        public ActionResult FindPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindPassword(string Tel, string TrueName)
        {
            string password = usersmanager.FindPassword(Tel, TrueName);
            return Content("<script>alert('" + password + "');window.location.href='../Users/FindPassword';</script>");

        }




        //退出时头像（视图）的变化 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TX()
        {
            //try
            //{
            Session.Abandon();
            Session["User_id"] = null;
            Session["User_image"] = null;
            Session.Remove("User_id");
            return PartialView();
            //return RedirectToAction("page", "Home");
        }
    }
}