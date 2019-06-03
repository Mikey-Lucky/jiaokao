using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IVideo
    {
        //热门视频
        IEnumerable<Video> Gethotvideo(int top);
        //最新视频
        IEnumerable<Video> Getnewvideo(int top);
        //根据视频id查找视频
        Video GetVideoById(int id);
        //查找前几条相关视频
        IEnumerable<Video> VideoRelative(int authorid, string title,string intro,int top);
        //通过用户id找所有视频
        IEnumerable<Video> uservideo(int userid);
        //添加视频
        void AddVideo(Video video);
        //删除视频
        bool DeleteVideo(int id);
        //修改视频
        void EditVideo(Video video);
    }
}
