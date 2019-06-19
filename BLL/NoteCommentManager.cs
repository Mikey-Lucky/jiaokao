using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class NoteCommentManager
    {
        INoteComment inotecomment = DataAccess.CreateNoteComment();
        public void AddNoteComment(NoteComment notecomment)
        {
            inotecomment.AddNoteComment(notecomment);
        }

        public IEnumerable<NoteComment> allnotecomment(int noteid)
        {

            return inotecomment.allnotecomment(noteid);
        }
        //删除笔记评论
        public bool delnotec(int notecid)
        {
            return inotecomment.delnotec(notecid);
        }
    }
}
