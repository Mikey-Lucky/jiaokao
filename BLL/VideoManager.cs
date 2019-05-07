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
    public class VideoManager
    {
        IVideo ivideo = DataAccess.CreateVideo();
        //根据点赞量获取热门视频
        public IEnumerable<video_like> GetHotVideo(int top)
        {
            var hotvideo = ivideo.Gethotvideo(top);
            return hotvideo;
        }
    }
}
