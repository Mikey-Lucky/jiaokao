using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IU_Reply_NoteComment
    {
        //评论id找到评论的所有回复
        IEnumerable<U_Reply_NoteComment> notecommentreply(int notecommentid);
        //添加笔记评论回复
        void AddNoteCommentReply(U_Reply_NoteComment notecommentreply);
    }
}
