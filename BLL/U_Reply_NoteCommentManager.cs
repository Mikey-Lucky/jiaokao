using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class U_Reply_NoteCommentManager
    {
        IU_Reply_NoteComment inotecommentreply = DataAccess.CreateU_Reply_NoteComment();
        public void AddNoteCommentReply(U_Reply_NoteComment notecommentreply)
        {
            inotecommentreply.AddNoteCommentReply(notecommentreply);
        }

        public IEnumerable<U_Reply_NoteComment> notecommentreply(int notecommentid)
        {
            return inotecommentreply.notecommentreply(notecommentid);
        }
    }
}
