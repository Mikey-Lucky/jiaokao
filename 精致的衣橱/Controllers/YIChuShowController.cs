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
        NoteLikeManager notelikes = new NoteLikeManager();
        VideoCommentManager vcomments = new VideoCommentManager();
        VideoSelectManager selects = new VideoSelectManager();
        // GET: YIChuShow
        public ActionResult Index()
        {
           
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
        /// <summary>
        /// 上传视频get
        /// </summary>
        /// <returns></returns>
        public ActionResult UpNote()
        {
            return View();
        }
        //上传视频post页面
        [HttpPost]
        [ValidateInput(false)]//富文本编辑器防拦截
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        public ActionResult UpNote(Note note)
        {
            var imgfile = Request.Files["imgfile"];
            var title = Request["title"];
            var notecontent = Request["content"];
            var imgpath= Guid.NewGuid().ToString() + imgfile.FileName;
            imgfile.SaveAs(Request.MapPath("/Images/Noteimg/" + imgpath));
            note.Title = title;
            note.NoteContent = notecontent;
            note.likenum = 0;
            note.Time = DateTime.Now;
            note.Img = "../Noteimg/" + imgpath;
            note.UserID = 1;
            notes.AddNote(note);
            return View();
        }
        //视频详情页
        public ActionResult VideoDetail(int id)
        {
            var video = videos.VideoDetail(id);
            return View(video);
        }
        //视频评论展示分布视图
        public ActionResult VideoComment(int videoid)
        {
            var videocomment = vcomments.allvideocomment(videoid);
            return PartialView(videocomment);
        }
        [HttpPost]
        public ActionResult VideoComment(VideoComment videocomment)
        {
            videocomment.Commentcotent = Request["comment"];
            videocomment.likenum = 0;
            videocomment.Time = DateTime.Now;
            videocomment.UserID = 1;
            videocomment.VideoID =Convert.ToInt32(Request["videoid"]) ;
            vcomments.AddVideoComment(videocomment);
            return View();
        }

        //相关笔记分布视图
        public ActionResult VideoRelative(int authorid, string title, string intro)
        {
            var video = videos.VideoRelative(authorid, title, intro);
            return PartialView(video);
        }
        public ActionResult Userhome()
        {
            ycsv.userlikenote = notelikes.userlikenote(1);
            ycsv.userlikevideo = likes.userlikevideo(1);
            ycsv.userupnote= notes.AllNoteByID(1);
            ycsv.userupvideo = videos.uservideo(1);

            return View(ycsv);
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
        public int Zan(int videoid)
        {

            int userid = 1;//测试用
            //videos.Videolikeclick(userid,videoid);
            likes.Videolikeclick(userid, videoid);
            int a = likes.videolikenum(videoid);
            return a;
        }
        //public int Select(int videoid)
        //{
        //    int userid = 1;//用于测试
        //    selects.VideoSelect(userid, videoid);
        //    int selectnum = selects.videoselectnum(videoid);
        //    return selectnum;
        //}
  

    }
}