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
        IEnumerable<video_like> Gethotvideo(int top);
    }
}
