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
        U_Attention_UManager attention = new U_Attention_UManager();
        UsersManager users = new UsersManager();
        U_Reply_VideoCommentManager ureplyvideocomment = new U_Reply_VideoCommentManager();
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
        //相关笔记分布视图
        public ActionResult NoteRelative(int authorid, string title)
        {
            var note = notes.NoteRelative(authorid, title, 5);
            return PartialView(note);
        }
        /// <summary>
        /// 上传笔记get
        /// </summary>
        /// <returns></returns>
        public ActionResult UpNote()
        {
            return View();
        }
        //上传笔记post页面
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
        
        //上传视频get
        public ActionResult UpVideo()
        {
           
            return View();
        }
        //上传视频post
        [HttpPost]
        public ActionResult UpVideo(Video video)
        {
            var video1 = Request.Files["video"];
            var videopath = Guid.NewGuid().ToString() + video1.FileName;
            video1.SaveAs(Request.MapPath("/Images/video/" + videopath));
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
            return Content("评论成功");
        }
        //视频评论回复分布视图
        public ActionResult VideoCommentReply(int commentid)
        {
            var urvc= ureplyvideocomment.videocommentreply(commentid);
            return PartialView(urvc);
        }
        [HttpPost]
        public ActionResult VideoCommentReply(U_Reply_VideoComment urvc)
        {
            urvc.VCContent = Request["commentreply"];
            urvc.VideocommentID = Convert.ToInt32(Request["videocommentid"]);
            urvc.UserID = 1;
            urvc.Likenum = 0;
            urvc.Time = DateTime.Now;
            ureplyvideocomment.AddVideoCommentReply(urvc);
            return Content("回复成功");
        }
        //相关视频分布视图
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
            ycsv.attentionnum = attention.attentionnum(1);
            ycsv.fensnum = attention.fensnum(1);
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
        //用户的关注
        public ActionResult Attention(int userid)
        {
            var a = attention.attention(userid);
            return View(a);
        }
        //用户信息卡分布视图
        public ActionResult usercard(int userid)
        {
            ycsv.fensnum = attention.fensnum(userid);
            ycsv.attentionnum = attention.attentionnum(userid);
            if (users.GetUserById(userid).Sex == null)
            {
                ycsv.sex = "保密";
             } else ycsv.sex = users.GetUserById(userid).Sex;
            ycsv.Userabout = users.GetUserById(userid);
            return PartialView(ycsv);
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