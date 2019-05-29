using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DALFactory;
using IDAL;

namespace BLL
{
    public class U_Reply_VideoCommentManager
    {
        IU_Reply_VideoComment ivideocommentreply = DataAccess.CreateU_Reply_VideoComment();
        //添加视频评论回复
        public void AddVideoCommentReply(U_Reply_VideoComment videocommentreply)
        {
            ivideocommentreply.AddVideoCommentReply(videocommentreply);
        }
        //视频评论的所有回复
        public IEnumerable<U_Reply_VideoComment> videocommentreply(int videocommentid)
        {
            return ivideocommentreply.videocommentreply(videocommentid);
        }
    }
}
