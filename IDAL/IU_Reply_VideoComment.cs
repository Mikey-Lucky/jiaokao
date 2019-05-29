using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IU_Reply_VideoComment
    {
        //评论id找到评论的所有回复
        IEnumerable<U_Reply_VideoComment> videocommentreply(int videocommentid);
        //添加视频评论回复
        void AddVideoCommentReply(U_Reply_VideoComment videocommentreply);
    }
}
