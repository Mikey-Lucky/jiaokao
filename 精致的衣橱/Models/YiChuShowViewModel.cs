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

    }
}