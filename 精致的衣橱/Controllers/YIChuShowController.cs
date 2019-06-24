using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using 精致的衣橱.Models;
using System.Web.Script.Serialization;
using 精致的衣橱.Attributes;

namespace 精致的衣橱.Controllers
{
    public class YIChuShowController : Controller
    {


        NoteManager notes = new NoteManager();
        NoteCommentManager ncomments = new NoteCommentManager();
        VideoManager videos = new VideoManager();
        YiChuShowViewModel ycsv = new YiChuShowViewModel();
        VideoLikeManager likes = new VideoLikeManager();
        NoteLikeManager notelikes = new NoteLikeManager();
        VideoCommentManager vcomments = new VideoCommentManager();
        VideoSelectManager selects = new VideoSelectManager();
        U_Attention_UManager attention = new U_Attention_UManager();
        UsersManager users = new UsersManager();
        U_Reply_NoteCommentManager ureplync = new U_Reply_NoteCommentManager();
        U_Reply_VideoCommentManager ureplyvideocomment = new U_Reply_VideoCommentManager();
        // GET: YIChuShow
      
        public ActionResult Index()
        {
           
            ycsv.JingXuanNote = notes.GetHotNote(30);
            ycsv.JingXuanVideo = videos.GetHotVideo(30);
            ycsv.NewNote = notes.Getnewnote(30);
            ycsv.NewVideo = videos.Getnewvideo(30);

            return View(ycsv);
        }
        //笔记详情页
        public ActionResult NoteDetail(int id)
        {
            ycsv.notedetail = notes.NoteDetail(id);
            ycsv.allnotecommentbyid = ncomments.allnotecomment(id);
            return View(ycsv);

            //var note = notes.NoteDetail(id);
            //return View(note);
        }
        public ActionResult notecomment(int noteid)
        {
            ycsv.allnotecommentbyid = ncomments.allnotecomment(noteid);
            return PartialView(ycsv);
        }
        //笔记评论post
        [HttpPost]
        public ActionResult notecomment(int noteid,string ccontent)
        {
            if (ccontent != null)
            {
                NoteComment nc = new NoteComment();
                nc.likenum = 0;
                nc.Nccontent = ccontent;
                nc.NoteID = noteid;
                nc.Time = DateTime.Now;
                nc.UserID =Convert.ToInt32(Session["User_id"]);
                ncomments.AddNoteComment(nc);
                ycsv.allnotecommentbyid = ncomments.allnotecomment(noteid);
                //return PartialView(ycsv);
                return Content("评论成功");
            }
            else return Content("请输入");
        }
        //删除笔记评论
        public string delnotec(int notecid)
        {
            var a=ncomments.delnotec(notecid);
            if (a)
            {
                return "删除成功";
            }
            else return "删除失败";
        }
        //笔记评论回复分布视图
        public ActionResult ncreply(int commentid)
        {
            var r=ureplync.notecommentreply(commentid);
            return PartialView(r);
        }
        [HttpPost]
        public ActionResult ncreply(int commentid,string rcontent)
        {
            if (rcontent!= null)
            {
                U_Reply_NoteComment rcomment = new U_Reply_NoteComment();
                rcomment.Likenum = 0;
                rcomment.NoteCommentID = commentid;
                rcomment.Time = DateTime.Now;
                rcomment.URNContent = rcontent;
                rcomment.UserID =Convert.ToInt32(Session["User_id"]);
                ureplync.AddNoteCommentReply(rcomment);
                //var r = ureplync.notecommentreply(commentid);
                var r = ureplync.notecommentreply(commentid);
                return PartialView(r);
            }
            else return Content("请输入");
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
            note.UserID =Convert.ToInt32(Session["User_id"]);
            notes.AddNote(note);
            //return View();
            return Content("<script>alert('发表成功');window.location.href='../YiChuShow/Index';</script>");
        }

        ////给笔记点赞
        //public void addnotelike(NoteLike like)
        //{
        //    like.NoteID =Convert.ToInt32(Request["noteid"]);
        //    like.UserID =Convert.ToInt32(Request["userid"]);
        //    like.Time = DateTime.Now;
        //    notelikes.addlike(like);
        //}
        ////取消笔记点赞
        //public bool delnotelike(int userid, int noteid)
        //{
        //    return notelikes.dellike(userid, noteid);
        //}
        //判断是否给笔记点过赞
        public string ifnotelike(int noteid)
        {
            var userid = Convert.ToInt32(Session["User_id"]);
            if (notelikes.iflike(userid, noteid) == true)
            {
                return "取消点赞";
            }
            else return "点赞";
            //return notelikes.iflike(userid, noteid);
        }
        //点赞取消赞操作
        public int notezan( int noteid)
        {
            var userid =Convert.ToInt32(Session["User_id"]);
            var a= notelikes.iflike(userid, noteid);
            if (a == true)
            {
                notelikes.dellike(userid, noteid);
                return notelikes.Notelikenum(noteid);
            }
            else {
                NoteLike like = new NoteLike();
                like.NoteID =noteid;
                like.UserID =userid;
                like.Time = DateTime.Now;
                notelikes.addlike(like);
                return notelikes.Notelikenum(noteid);
            }
        }
        //上传视频get
        public ActionResult UpVideo()
        {
           
            return View();
        }
        //上传视频post
        [HttpPost]
        public ActionResult UpVideo(Video videor)
        {
            var imgfile = Request.Files["imgfile"];
            var video1 = Request.Files["video"];
            var title = Request["title"];
            var intro = Request["intro"];
            var videopath = Guid.NewGuid().ToString() + video1.FileName;
            var imgpath= Guid.NewGuid().ToString() + imgfile.FileName;
            video1.SaveAs(Request.MapPath("/Images/video/" + videopath));
            imgfile.SaveAs(Request.MapPath("/Images/videoimg/" + imgpath));

            videor.Adress = "../video/" + videopath;
            videor.Image = "../videoimg/" + imgpath;
            videor.Intro = intro;
            videor.likenum = 0;
            videor.Time = DateTime.Now;
            videor.Title = title;
            videor.UserID =Convert.ToInt32(Session["User_id"]);
            videos.AddVideo(videor);
            return View();
        }
        //视频详情页
        public ActionResult VideoDetail(int id)
        {
            ycsv.videodetail = videos.VideoDetail(id);
            ycsv.allvideocommentbyid = vcomments.allvideocomment(id);
            //var video = videos.VideoDetail(id);
            return View(ycsv);
        }
        //删除笔记评论
        public string delvideoc(int videocid)
        {
            var a = vcomments.delvideoc(videocid);
            if (a)
            {
                return "删除成功";
            }
            else return "删除失败";
        }
        //视频评论展示分布视图
        public ActionResult VideoComment(int videoid)
        {
            ycsv.allvideocommentbyid= vcomments.allvideocomment(videoid);
            //var videocomment = vcomments.allvideocomment(videoid);
            return PartialView(ycsv);
        }
        [HttpPost]
        public ActionResult VideoComment(VideoComment videocomment)
        {
            videocomment.Commentcotent = Request["comment"];
            videocomment.likenum = 0;
            videocomment.Time = DateTime.Now;
            videocomment.UserID = Convert.ToInt32(Session["User_id"]);
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
            urvc.VCContent = Request["rcontent"];
            urvc.VideocommentID = Convert.ToInt32(Request["commentid"]);
            urvc.UserID = Convert.ToInt32(Session["User_id"]);
            urvc.Likenum = 0;
            urvc.Time = DateTime.Now;
            ureplyvideocomment.AddVideoCommentReply(urvc);
            var a = ureplyvideocomment.videocommentreply(Convert.ToInt32(Request["commentid"]));
            return PartialView(a);
        }
        //相关视频分布视图
        public ActionResult VideoRelative(int authorid, string title, string intro)
        {
            var video = videos.VideoRelative(authorid, title, intro);
            return PartialView(video);
        }
        [Login]
        public ActionResult Userhome(int userid)
        {
            ycsv.userlikenote = notelikes.userlikenote(userid);
            ycsv.userlikevideo = likes.userlikevideo(userid);
            ycsv.userupnote= notes.AllNoteByID(userid);
            ycsv.userupvideo = videos.uservideo(userid);
            ycsv.attentionnum = attention.attentionnum(userid);
            ycsv.fensnum = attention.fensnum(userid);
            ycsv.Userabout = users.GetUserById(userid);
            return View(ycsv);
        }
        //查看个人信息
        public ActionResult userabout()
        {
            int userid =Convert.ToInt32(Session["User_id"]);
            ycsv.Userabout = users.GetUserById(userid);
            return View(ycsv);
        }
        //删除视频
        public string delvideo(int videoid)
        {
            videos.DeleteVideo(videoid);
            return "删除成功";
        }
        //删除笔记
        public string delnote(int noteid)
        {
            notes.DeleteNote(noteid);
            return "删除成功";
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
        //用户的粉丝
        public ActionResult FenSi(int userid)
        {
            var f = attention.fens(userid);
            return View(f);
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
        //用户是否关注
        public string ifattention(int beiguanzhuid)
        {
            int guanzhuzheid = Convert.ToInt32(Session["User_id"]);
            return attention.ifattention(guanzhuzheid, beiguanzhuid);
        }
        //取消关注
     
        public string quguan(int guanzhuzheid, int beiguanzhuid)
        {
            attention.deleteattention(guanzhuzheid, beiguanzhuid);
            return "取关成功";
        }
        //加关注
     
        public string jiaguan(U_Attention_U uau)
        {
            uau.User1ID =Convert.ToInt32(Request["guanzhuzheid"]);
            uau.User2ID = Convert.ToInt32(Request["beiguanzhuid"]);
            uau.Time = DateTime.Now;
            attention.addattention(uau);
            return "关注成功";
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