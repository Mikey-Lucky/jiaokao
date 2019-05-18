using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 精致的衣橱.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<GGCC> Season { get; set; }
        public IEnumerable<GGCC> Sex { get; set; }
        public IEnumerable<GGCC> Style { get; set; }
        public IEnumerable<GGCC> Material { get; set; }
        public IEnumerable<GGCC> Color { get; set; }
    }
}