using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlVideoSelect : IVideoSelect
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void VideoSelect(int userid, int videoid)
        {
           VideoSelect select = db.VideoSelect.Where(b => b.UserID == userid && b.VideoID == videoid).FirstOrDefault();
            if (select != null)
            {
                db.VideoSelect.Remove(select);
                db.SaveChanges();
            }
            else
            {
                VideoSelect select1 = new VideoSelect();
                select1.VideoID = videoid;
                select1.UserID = userid;
                select1.Time = DateTime.Now;
                db.VideoSelect.Add(select1);
                db.SaveChanges();
            }
        }
    }
}
