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
        public ActionResult Index()
        {
            var note=notes.GetHotNote(12);
            var video = videos.GetHotVideo(5);
            HomeIndexViewModel homeindexviewmodel = new HomeIndexViewModel();
            homeindexviewmodel.notes = note;
            homeindexviewmodel.videos = video;
            return View(homeindexviewmodel);
        }
    }
}