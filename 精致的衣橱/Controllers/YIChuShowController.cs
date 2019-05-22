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
    public class YIChuShowController : Controller
    {

        NoteManager notes = new NoteManager();
        YiChuShowViewModel ycsv = new YiChuShowViewModel();
        // GET: YIChuShow
        public ActionResult Index()
        {
            var a=notes.GetHotNote(20);
            Response.Write(a);
            return View();
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