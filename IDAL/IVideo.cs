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
        //根据视频id查找时评
        Video GetVideoById(int id);
        //查找前几条相关视频
        IEnumerable<Video> VideoRelative(int authorid, string title,string intro,int top);
     

    }
}
