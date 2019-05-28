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
        //视频点赞的数量
        public int videolikenum(int videoid)
        {
            return ilike.videolikenum(videoid);
        }
        //用户喜欢视频的所有数据
        public IEnumerable<VideoLike> userlikevideo(int userid)
        {
            return ilike.userlikevideo(userid);
        }
    }
}
