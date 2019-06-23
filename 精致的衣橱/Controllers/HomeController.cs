using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using 精致的衣橱.Models;

namespace 精致的衣橱.Controllers
{
    public class HomeController : Controller
    {
        NoteManager notes = new NoteManager();
        VideoManager videos = new VideoManager();
        GoodsManager goods = new GoodsManager();
        
        public ActionResult Index()
        {
            var note=notes.GetHotNote(8);
            var video = videos.GetHotVideo(6);
            var hgood = goods.GetHotGoods(3);
            var ngood = goods.GetNewGoods(6);
            HomeIndexViewModel homeindexviewmodel = new HomeIndexViewModel();
            homeindexviewmodel.notes = note;
            homeindexviewmodel.videos = video;
            homeindexviewmodel.hotgoods = hgood;
            homeindexviewmodel.newgoods = ngood;
            return View(homeindexviewmodel);
        }
        public ActionResult Index1()
        {
            var note = notes.GetHotNote(8);
            var video = videos.GetHotVideo(6);
            var hgood = goods.GetHotGoods(3);
            var ngood = goods.GetNewGoods(6);
            HomeIndexViewModel homeindexviewmodel = new HomeIndexViewModel();
            homeindexviewmodel.notes = note;
            homeindexviewmodel.videos = video;
            homeindexviewmodel.hotgoods = hgood;
            homeindexviewmodel.newgoods = ngood;
            return View(homeindexviewmodel);
        }
    }
}