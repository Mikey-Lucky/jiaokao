using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INoteLike
    {
        //对笔记点赞表进行增删操作
        void Notelikeclick(int userid, int noteid);
        //视频点赞数量
        int Notelikenum(int noteid);
        //通过用户id找到用户的喜欢笔记列表
        IEnumerable<NoteLike> userlikenote(int userid);
        //判断用户是否点赞了笔记
        bool iflike (int userid, int noteid);
        //取消赞
        bool dellike(int userid, int noteid);
        //点赞
        void addlike(NoteLike like);

    }
}
