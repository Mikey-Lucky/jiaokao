using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IVideoLike
    {
        //对视频点赞表进行增删操作
        void Videolikeclick(int userid, int videoid);
        //视频点赞数量
        int videolikenum(int videoid);
        //通过用户id找到用户的喜欢视频列表
        IEnumerable<VideoLike> userlikevideo(int userid);
    }
}
