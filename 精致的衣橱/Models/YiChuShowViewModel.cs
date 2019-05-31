using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace 精致的衣橱.Models
{
    public class YiChuShowViewModel
    {
        //用户所有的笔记
        public IQueryable<Note> AllNoteByID { get; set; }
        //精选笔记
        public IEnumerable<Note> JingXuanNote { get; set; }
        //精选视频
        public IEnumerable<Video> JingXuanVideo { get; set; }
        //热门show主
        public IEnumerable<Users> HotUser { get; set; }
        //最新笔记
        public IEnumerable<Note> NewNote { get; set; }
        //最新视频
        public IEnumerable<Video> NewVideo { get; set; }
        //用户喜欢的视频
        public IEnumerable<VideoLike> userlikevideo { get; set; }
        //用户喜欢的笔记
        public IEnumerable<NoteLike> userlikenote { get; set; }
        //用户发表过的笔记
        public IEnumerable<Note> userupnote { get; set; }
        //用户上传过的视频
        public IEnumerable<Video> userupvideo { get; set; }
        ////用户的所有关注
        //public IQueryable<U_Attention_U> attention { get; set; }
        ////用户的所有粉丝
        //public IQueryable<U_Attention_U> fens { get; set; }

        //用户关注的数量
        public int attentionnum { get; set; }
        //用户粉丝的数量
        public int fensnum { get; set; }
        //用户性别
        public string sex { get; set; }
        //用户信息
        public Users Userabout { get; set; }
    }
}