using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlVideoLike:IVideoLike
    {
    
        yichuEntities db = DbContextFactory.CreateDbContext();

      

        public void Videolikeclick(int userid, int videoid)
        {
            VideoLike like = db.VideoLike.Where(b => b.UserID == userid && b.VideoID == videoid).FirstOrDefault();
            if (like != null)
            {
                db.VideoLike.Remove(like);
                db.SaveChanges();
            }
            else
            {
                VideoLike like1 = new VideoLike();
                like1.VideoID = videoid;
                like1.UserID = userid;
                like1.Time = DateTime.Now;
                db.VideoLike.Add(like1);
                db.SaveChanges();
            }
        }

        public int videolikenum(int videoid)
        {
            int likenum = db.VideoLike.Where(v => v.VideoID == videoid).Count();
            return likenum;
        }
        public IEnumerable<VideoLike> userlikevideo(int userid)
        {
            var likevideo = db.VideoLike.Where(l => l.UserID == userid);
            return likevideo;
        }
    }
}
