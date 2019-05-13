using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using 精致的衣橱.Models;

namespace 精致的衣橱.Controllers
{
    public class MallController : Controller
    {
        // GET: Mall
        yichuEntities db = new yichuEntities();
        GoodsManager goodsmanager = new GoodsManager();
        public ActionResult Index()
        {
            var g1 = goodsmanager.GetHotGoods(8);
            var g2 = goodsmanager.GetNewGoods(10);
            var g3 = goodsmanager.Chun(12);
            MallViewModel mallviewmodel = new MallViewModel();
            mallviewmodel.HotGoods = g1;
            mallviewmodel.NewGoods = g2;
            mallviewmodel.Chun = g3;
            return View(mallviewmodel);
        }
    }
}