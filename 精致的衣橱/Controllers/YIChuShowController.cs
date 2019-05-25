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
        VideoLikeManager likes = new VideoLikeManager();
        // GET: YIChuShow
        public ActionResult Index()
        {
            likes.Videolikeclick(1, 1);
            ycsv.JingXuanNote = notes.GetHotNote(30);
            ycsv.JingXuanVideo = videos.GetHotVideo(30);
            ycsv.NewNote = notes.Getnewnote(30);
            ycsv.NewVideo = videos.GetHotVideo(30);

            return View(ycsv);
        }
        //笔记详情页
        public ActionResult NoteDetail(int id)
        {
            var note = notes.NoteDetail(id);
            return View(note);
        }
        //视频详情页
        public ActionResult VideoDetail(int id)
        {
            var video = videos.VideoDetail(id);
            return View(video);
        }
        //相关笔记分布视图
        public ActionResult VideoRelative(int authorid, string title, string intro)
        {
            var video = videos.VideoRelative(authorid, title, intro);
            return PartialView(video);
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
        //点赞取消赞操作
        public string Zan(int videoid)
        {
            //int userid = 1;
            //videos.Videolikeclick(userid,videoid);
            
            return videoid.ToString();
        }

    }
}