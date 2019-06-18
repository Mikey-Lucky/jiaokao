using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using System.Data.Entity;

namespace DAL
{
    public class SqlVideo : IVideo
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

       

        public IEnumerable<Video> Gethotvideo(int top)
        {
            var hotvideo = from v in db.Video
                          orderby v.likenum descending
                          select v;

            return hotvideo.Take(top);
        }

        public IEnumerable<Video> Getnewvideo(int top)
        {
            return db.Video.OrderByDescending(o => o.Time).Take(top); 
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
        public IEnumerable<Video> uservideo(int userid)
        {
           var video= from v in db.Video
                      where v.UserID==userid
                      select v;
            return video;
        }

        public void AddVideo(Video video)
        {
            db.Video.Add(video);
            db.SaveChanges();
        }

        public bool DeleteVideo(int id)
        {
            Video video = db.Video.Where(b => b.VideoID == id).FirstOrDefault();
            if (video != null)
            {
                db.Video.Remove(video);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public void EditVideo(Video video)
        {
            db.Entry(video).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
