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
        public IEnumerable<Video> GetHotVideo(int top)
        {
            var hotvideo = ivideo.Gethotvideo(top);
            return hotvideo;
        }
        //获取最新视频
        public IEnumerable<Video> Getnewvideo(int top)
        {
            return ivideo.Getnewvideo(top);
        }
        //视频详情
        public Video VideoDetail(int id)
        {
            return ivideo.GetVideoById(id);
        }
        //查找相关的五条视频
        public IEnumerable<Video> VideoRelative(int authorid, string title, string intro)
        {
            return ivideo.VideoRelative(authorid, title, intro,5);
        }
    
    }

}
