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
    public class GoodsLikeManager
    {
        IGoodsLike igoodlike = DataAccess.CreateGoodsLike();
        public void GoodsLikeClick(int userid, int goodsid)
        {
            igoodlike.GoodsLikeClick(userid,goodsid);
        }
        public int goodslikenum(int goodsid)
        {
            return igoodlike.goodslikenum(goodsid);
        }


    }
}
