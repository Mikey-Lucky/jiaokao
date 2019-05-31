using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IComReply
    {
        IEnumerable<ComReply> Reply(int commentid);
        void AddComReply(int userid,int goodscommentid,string replycontent,DateTime replytime);
    }
}
