using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IGoodsComment
    {
        IEnumerable<GoodsComment> Getgoodscomment();
        IEnumerable<GoodsComment> Getgoodscommentbyid(int? id);
        void AddGoodsComment(string com, int userid, int goodsid, DateTime datetime, int num);
    }
}
