using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using IDAL;
using DALFactory;
using Models;

namespace BLL
{
    
    public class ComReplyManager
    {
        IComReply icomreply = DataAccess.CreateComReply();
        public IEnumerable<ComReply> Reply(int commentid)
        {
            var reply = icomreply.Reply(commentid);
            return reply;

        }
        public void AddComReply(int userid, int goodscommentid, string replycontent, DateTime replytime)
        {
           icomreply.AddComReply(userid,goodscommentid,replycontent,replytime);
        }
    }
}
