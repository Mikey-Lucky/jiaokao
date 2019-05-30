using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class NoteManager
    {
        
        INote inote = DataAccess.CreateNote();
        public IEnumerable<Note> GetHotNote(int top)
        {
            var hotnote = inote.Gethotnote(top);
            return hotnote;
        }
        //通过用户id查询笔记
        public IQueryable<Note> AllNoteByID(int id)
        {
            return inote.AllNoteByID(id);
        }
        //添加笔记
        public void AddNote(Note note)
        {
            inote.AddNote(note);
        }
        //删除笔记
        public bool DeleteNote(int id)
        {
            inote.DeleteNote(id);
            return true;
        }
        //修改笔记
        public void EditNote(Note note)
        {
            inote.EditNote(note);
        }
        //查找最新笔记
        public IEnumerable<Note> Getnewnote(int top)
        {
            return inote.Getnewnote(top);
        }
        //笔记详情
        public Note NoteDetail(int id)
        {
            return inote.GetNoteById(id);
        }
        //相关的前几条笔记
        public IEnumerable<Note> NoteRelative(int authorid, string title, int top)
        {
            return inote.NoteRelative(authorid,title,top);
        }

    }
}
