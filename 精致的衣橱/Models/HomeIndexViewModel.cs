using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace 精致的衣橱.Models
{
    public class HomeIndexViewModel
    {
        //笔记部分
        public IEnumerable<Note> notes { get; set; }
        //视频
        public IEnumerable<Video> videos { get; set; }
        //热门商品
        public IEnumerable<Goods> hotgoods { get; set; }
        //最新上架商品
        public IEnumerable<Goods> newgoods { get; set; }

    }
}