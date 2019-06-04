using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class U_Attention_UManager
    {
        IU_Attention_U iattention = DataAccess.CreateU_Attention_U();
        //加关注
        public void addattention(U_Attention_U attention)
        {
            iattention.addattention(attention);
        }
        //取消关注
        public bool deleteattention(int guanzhuzheid, int beiguanzhuid)
        {
            return iattention.deleteattention(guanzhuzheid,beiguanzhuid);
        }
        //用户的关注
        public IQueryable<U_Attention_U> attention(int userid)
        {
            return iattention.attention(userid);
        }
        //用户的粉丝
        public IQueryable<U_Attention_U> fens(int userid)
        {
            return iattention.fens(userid);
        }
        //用户粉丝数量
        public int fensnum(int userid)
        {
            return iattention.fensnum(userid);
        }
        //用户关注的数量
        public int attentionnum(int userid)
        {
            return iattention.attentionnum(userid);
        }
        //判断用户是否关注某用户
        public string ifattention(int guanzhuzheid, int beiguanzhuid)
        {
            return iattention.ifattention(guanzhuzheid, beiguanzhuid);
        }
    }
}
