﻿using System;
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
            var a = db.Goods.Where(p=>p.GoodsID==id).FirstOrDefault();
            return View(a);
        }
    }
}