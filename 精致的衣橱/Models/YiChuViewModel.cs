﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace 精致的衣橱.Models
{
    public class YiChuViewModel
    {
        //春季上单衣
        public IEnumerable<Shirt> springshirt { get; set; }
        //夏季上单衣
        public IEnumerable<Shirt> summershirt { get; set; }
        //秋季上单衣
        public IEnumerable<Shirt> autumnshirt { get; set; }
        //冬季上单衣
        public IEnumerable<Shirt> wintershirt { get; set; }
        //春季套装
        public IEnumerable<Suit> springsuit { get; set; }
        //夏季套装
        public IEnumerable<Suit> summersuit { get; set; }
        //秋季套装
        public IEnumerable<Suit> autumnsuit { get; set; }
        //冬季套装
        public IEnumerable<Suit> wintersuit { get; set; }
        //春季外套
        public IEnumerable<Coat> springcoat { get; set; }
        //夏季外套
        public IEnumerable<Coat> summercoat { get; set; }
        //秋季外套
        public IEnumerable<Coat> autumncoat { get; set; }
        //冬季外套
        public IEnumerable<Coat> wintercoat { get; set; }
        //春季下装
        public IEnumerable<NetherGarment> springnethergarment { get; set; }
        //夏季下装
        public IEnumerable<NetherGarment> summernethergarment { get; set; }
        //秋季下装
        public IEnumerable<NetherGarment> autumnnethergarment { get; set; }
        //冬季下装
        public IEnumerable<NetherGarment> winternethergarment { get; set; }
    }
}