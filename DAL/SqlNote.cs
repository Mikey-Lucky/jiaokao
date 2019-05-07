using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlNote : INote
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        //获取热门笔记，根据点赞数量
        public IEnumerable<Note> Gethotnote(int top)
        {
            var hotnote = from note in db.Note
                          orderby note.likenum ascending
                          select note;
            return hotnote.Take(top);
        }
    }
}
