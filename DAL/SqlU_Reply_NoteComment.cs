using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlU_Reply_NoteComment : IU_Reply_NoteComment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void AddNoteCommentReply(U_Reply_NoteComment notecommentreply)
        {
            db.U_Reply_NoteComment.Add(notecommentreply);
            db.SaveChanges();
        }

        public IEnumerable<U_Reply_NoteComment> notecommentreply(int notecommentid)
        {
            var commentreply = from c in db.U_Reply_NoteComment
                               where c.NoteCommentID == notecommentid
                               select c;
            return commentreply;
        }
    }
}
