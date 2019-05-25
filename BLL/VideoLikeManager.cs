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
    public class VideoLikeManager
    {
        IVideoLike ilike = DataAccess.CreateVideoLike();
        public void Videolikeclick(int userid, int videoid)
        {
            ilike.Videolikeclick(userid, videoid);
        }
    }
}
