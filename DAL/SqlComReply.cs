using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlComReply:IComReply
    {
        yichuEntities db = new yichuEntities();
        public IEnumerable<ComReply> Reply(int commentid)
        {
            return db.ComReply.Where(p=>p.GoodsCommentID==commentid).OrderByDescending(t=>t.RepTime);
        }
        public void AddComReply(int userid, int goodscommentid, string replycontent, DateTime replytime)
        {
            var comreply = new ComReply()
            {
                UserID = userid,
                GoodsCommentID = goodscommentid,
                RepContent = replycontent,
                RepTime = replytime
            };
            db.ComReply.Add(comreply);
            db.SaveChanges();
            
        }
    }
}
