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
    }
}