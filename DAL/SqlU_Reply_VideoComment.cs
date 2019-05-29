using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlU_Reply_VideoComment:IU_Reply_VideoComment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public void AddVideoCommentReply(U_Reply_VideoComment videocommentreply)
        {
            db.U_Reply_VideoComment.Add(videocommentreply);
            db.SaveChanges();
        }

        public IEnumerable<U_Reply_VideoComment> videocommentreply(int videocommentid)
        {
            var commentreply = from c in db.U_Reply_VideoComment
                               where c.VideocommentID == videocommentid
                               select c;
            return commentreply;
        }
    }
}
