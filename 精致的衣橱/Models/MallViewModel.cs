using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 精致的衣橱.Models
{
    public class MallViewModel
    {
        public IEnumerable<Goods> HotGoods { get; set; }
        public IEnumerable<Goods> NewGoods { get; set; }
        public IEnumerable<Goods> ChunQiu { get; set; }
        public IEnumerable<Goods> Xia { get; set; }
        public IEnumerable<Goods> Dong { get; set; }
        public IEnumerable<Goods> allgoodsbytype{ get; set; }

    }
}