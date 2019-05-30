using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using System.Data.Entity;

namespace DAL
{
    public class SqlNote : INote
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public void AddNote(Note note)
        {
            db.Note.Add(note);
            db.SaveChanges();
        }

        public IQueryable<Note> AllNoteByID(int id)
        {
            return db.Note.OrderByDescending(o => o.Time).Where(b => b.UserID == id);
        }

        public bool DeleteNote(int id)
        {
            Note note = db.Note.Where(b => b.NoteID == id).FirstOrDefault();
            IQueryable<NoteComment> nc = db.NoteComment.Where(b => b.NoteID == id);
            if (note != null)
            {
                db.Note.Remove(note);
                db.NoteComment.RemoveRange(nc);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public void EditNote(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
        }

        //获取热门笔记，根据点赞数量
        public IEnumerable<Note> Gethotnote(int top)
        {
            var hotnote = from note in db.Note
                          orderby note.likenum descending
                          select note;
            return hotnote.Take(top);
        }

        public IEnumerable<Note> Getnewnote(int top)
        {
            return db.Note.OrderByDescending(o => o.Time).Take(top);
        }

        public Note GetNoteById(int id)
        {
            var note = from n in db.Note
                        where n.NoteID == id
                        select n;
            return note.FirstOrDefault();
        }

        public IEnumerable<Note> NoteRelative(int authorid, string title, int top)
        {
            var note = from n in db.Note
                        where (n.NoteContent.Contains(title) || n.Title.Contains(title)  || n.UserID == authorid) && n.Title != title
                        select n;
            return note.Take(top);
        }
    }
}
