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
    public class VideoSelectManager
    {
        IVideoSelect iselect = DataAccess.CreateVideoSelect();
        //用户收藏或取消收藏视频
        public void VideoSelect(int userid, int videoid)
        {
            iselect.VideoSelect(userid, videoid);
        }
        //视频点赞总数

    }
}
