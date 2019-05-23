using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using 精致的衣橱.Models;
using System.Web.Script.Serialization;

namespace 精致的衣橱.Controllers
{
    public class YIChuShowController : Controller
    {

        NoteManager notes = new NoteManager();
        VideoManager videos = new VideoManager();
        YiChuShowViewModel ycsv = new YiChuShowViewModel();
        // GET: YIChuShow
        public ActionResult Index()
        {
            ycsv.JingXuanNote = notes.GetHotNote(20);
            ycsv.JingXuanVideo = videos.GetHotVideo(20);
            ycsv.NewNote = notes.Getnewnote(20);
            ycsv.NewVideo = videos.GetHotVideo(20);

            return View(ycsv);
        }
        public ActionResult Userhome()
        {
            return View();
        }
      
        public ActionResult UserAllNote()
        {
            //通过用户id找说说
            //var usershuoshuo = notes.AllNoteByID(Convert.ToInt32(Session["User_id"]));
            //便于测试
            var usershuoshuo = notes.AllNoteByID(1);
            ycsv.AllNoteByID = usershuoshuo;
            return View(ycsv);
        }
    }
}