using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INote
    {
        //热门帖子
        IEnumerable<Note> Gethotnote(int top);
        //查找最新笔记
        IEnumerable<Note> Getnewnote(int top);
        //通过用户id查询笔记
        IQueryable<Note> AllNoteByID(int id);
        //添加笔记
        void AddNote(Note note);
        //删除笔记
        bool DeleteNote(int id);
        //修改笔记
        void EditNote(Note note);
        //更具笔记id查找上衣
        Note GetNoteById(int id);
        //查找前几条相关笔记
        IEnumerable<Note> NoteRelative(int authorid, string title, int top);
    }
}
