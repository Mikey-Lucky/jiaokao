using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IGoodsLike
    {
        //对商品点赞表进行增删操作
        void GoodsLikeClick(int userid, int goodsid);
        //商品点赞数量
        int goodslikenum(int goodsid);
    }
}
