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
        public IEnumerable<Video> Gethotvideo(int top)
        {
            var hotvideo = from v in db.Video
                          orderby v.likenum ascending
                          select v;

            return hotvideo.Take(top);
        }
    }
}
