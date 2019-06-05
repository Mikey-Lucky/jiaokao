using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using 精致的衣橱.Models;

namespace 精致的衣橱.Controllers
{
    public class MallManagerController : Controller
    {
        yichuEntities db = new yichuEntities();
        GoodsManager goodsmanager = new GoodsManager();
        // GET: MallManager
        public ActionResult Index()
        {
            return View();
        }
        
    }
}