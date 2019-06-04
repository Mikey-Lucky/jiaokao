using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class NoteLikeManager
    {
        INoteLike ilike = DataAccess.CreateNoteLike();
        public void Notelikeclick(int userid, int noteid)
        {
            ilike.Notelikeclick(userid, noteid);
        }

        public int Notelikenum(int noteid)
        {
            return ilike.Notelikenum(noteid);
        }
      
        public IEnumerable<NoteLike> userlikenote(int userid)
        {

            return ilike.userlikenote(userid);
        }
        //点赞
        public void addlike(NoteLike like)
        {
            ilike.addlike(like);
        }
        //取消点赞
        public bool dellike(int userid, int noteid)
        {
            return ilike.dellike(userid, noteid);
        }
        //判断是否点赞
        public bool iflike(int userid, int noteid)
        {
            return ilike.iflike(userid, noteid);
        }
    }
}
