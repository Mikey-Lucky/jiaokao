using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using 精致的衣橱.Models;
using 精致的衣橱.Attributes;

namespace 精致的衣橱.Controllers
{
    public class MallManagerController : Controller
    {
        yichuEntities db = new yichuEntities();
        GoodsManager goodsmanager = new GoodsManager();
        // GET: MallManager
        [Login]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}