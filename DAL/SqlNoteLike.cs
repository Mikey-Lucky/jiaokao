using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlNoteLike : INoteLike
    {
        yichuEntities db = DbContextFactory.CreateDbContext();



        public void Notelikeclick(int userid, int noteid)
        {
            NoteLike like = db.NoteLike.Where(b => b.UserID == userid && b.NoteID == noteid).FirstOrDefault();
            if (like != null)
            {
                db.NoteLike.Remove(like);
                db.SaveChanges();
            }
            else
            {
                NoteLike like1 = new NoteLike();
                like1.NoteID = noteid;
                like1.UserID = userid;
                like1.Time = DateTime.Now;
                db.NoteLike.Add(like1);
                db.SaveChanges();
            }
        }

        public int Notelikenum(int noteid)
        {
            int likenum = db.NoteLike.Where(v => v.NoteID == noteid).Count();
            return likenum;
        }

        public IEnumerable<NoteLike> userlikenote(int userid)
        {
            var likenote = db.NoteLike.Where(l => l.UserID == userid);
            return likenote;
        }
        public void addlike(NoteLike like)
        {
            db.NoteLike.Add(like);
            db.SaveChanges();
        }

        public bool dellike(int userid, int noteid)
        {
            NoteLike like = db.NoteLike.Where(b => b.UserID == userid && b.NoteID == noteid).FirstOrDefault();
            if (like != null)
            {
                db.NoteLike.Remove(like);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool iflike(int userid, int noteid)
        {
            NoteLike like = db.NoteLike.Where(a => a.UserID == userid && a.NoteID == noteid).FirstOrDefault();
            if (like!=null)
            {
                return true;
            }
            else return false;
        }
    }
}
