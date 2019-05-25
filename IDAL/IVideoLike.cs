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
    }
}
