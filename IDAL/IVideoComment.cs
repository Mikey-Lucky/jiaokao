using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IVideoComment
    {
        //视频id找到视频的所有评论
        IEnumerable<VideoComment> allvideocomment(int videoid);
        //添加视频评论
        void AddVideoComment(VideoComment videocomment);
        //删除视频评论
        bool delvideoc(int videocid);
    
    }
}
