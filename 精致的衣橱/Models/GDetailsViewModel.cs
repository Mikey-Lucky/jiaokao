using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 精致的衣橱.Models
{
    public class GDetailsViewModel
    {
        public IEnumerable<Goods> goods { get; set; }
        public IEnumerable<Goods_Color> goods_color { get; set; }
        public IEnumerable<Goods_Size> goods_size { get; set; }
        public IEnumerable<GoodsLike> goods_like { get; set; }
        public IEnumerable<GoodsComment> goods_comment { get; set; }
        public IEnumerable<GoodsCommentsLike> goodscomment_like { get; set; }

    }
}