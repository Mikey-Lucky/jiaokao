using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IVideoSelect
    {
        //对视频收藏表进行增删操作
        void VideoSelect(int userid, int videoid);
        //视频被收藏的总量
        int videoselectnum(int videoid);
    }
}
