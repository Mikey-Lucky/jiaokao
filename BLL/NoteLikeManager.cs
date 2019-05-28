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
    }
}
