using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DALFactory;
using IDAL;


namespace BLL
{
    public class VideoCommentManager
    {

        IVideoComment ivideocomment = DataAccess.CreateVideoComment();
        //通过视频id找出所有视频评论
        public IEnumerable<VideoComment> allvideocomment(int videoid)
        {
            return ivideocomment.allvideocomment(videoid);
        }
        //添加视频评论
        public void AddVideoComment(VideoComment videocomment)
        {
            ivideocomment.AddVideoComment(videocomment);
        }
        //删除视频评论
        public bool delvideoc(int videocid)
        {
            return ivideocomment.delvideoc(videocid);
        }
    }
}
