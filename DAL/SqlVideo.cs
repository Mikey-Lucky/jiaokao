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

        public IEnumerable<Video> Getnewvideo(int top)
        {
            return db.Video.OrderByDescending(o => o.Time); 
        }

        public Video GetVideoById(int id)
        {
            var video = from v in db.Video
                        where v.VideoID == id
                        select v;
            return video.FirstOrDefault();
        }
        public IEnumerable<Video> VideoRelative(int authorid, string title, string intro, int top)
        {
            var video = from v in db.Video
                        where (v.Intro.Contains(title) || v.Title.Contains(title) || v.Intro.Contains(intro) || v.UserID == authorid) && v.Title != title
                        select v;
            return video.Take(top);
        }
  
    }
}
