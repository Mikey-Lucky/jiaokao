using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlVideo : IVideo
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<video_like> Gethotvideo(int top)
        {
            var hotvideo = from video in db.video_like
                          orderby video.num ascending
                          select video;

            return hotvideo.Take(top);
        }
    }
}
