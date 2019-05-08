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
            var note=notes.GetHotNote(10);
            var video = videos.GetHotVideo(5);
            var hgood = goods.GetHotGoods(5);
            var ngood = goods.GetNewGoods(5);
            HomeIndexViewModel homeindexviewmodel = new HomeIndexViewModel();
            homeindexviewmodel.notes = note;
            homeindexviewmodel.videos = video;
            homeindexviewmodel.hotgoods = hgood;
            homeindexviewmodel.newgoods = ngood;
            return View(homeindexviewmodel);
        }
    }
}