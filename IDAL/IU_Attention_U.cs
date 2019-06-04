using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IU_Attention_U
    {
        //增加关注
        void addattention(U_Attention_U attention);
        //删除关注
        bool deleteattention(int guanzhuzheid,int beiguanzhuid);
        //找出用户的关注
        IQueryable<U_Attention_U> attention(int userid);
        //找出用户的粉丝
        IQueryable<U_Attention_U> fens(int userid);
        //用户粉丝的数量
        int fensnum(int userid);
        //用户关注的数量
        int attentionnum(int userid);
        //判断用户是否关注了某用户
        string ifattention(int guanzhuzheid, int beiguanzhuid);
    }
}
