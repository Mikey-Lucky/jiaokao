using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INoteComment
    {
        //视频id找到笔记的所有评论
        IEnumerable<NoteComment> allnotecomment(int noteid);
        //添加笔记评论
        void AddNoteComment(NoteComment notecomment);
        //删除笔记评论
        bool delnotec(int notecid);
    }
}
