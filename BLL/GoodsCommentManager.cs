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
    public class GoodsCommentManager
    {
        IGoodsComment igc = DataAccess.CreateGoodsComment();
        public IEnumerable<GoodsComment> Getgoodscomment()
        {
            var goodscomment = igc.Getgoodscomment();
            return goodscomment;
        }
        public IEnumerable<GoodsComment> Getgoodscommentbyid(int? id)
        {
            var commentbyid = igc.Getgoodscommentbyid(id);
            return commentbyid;
        }
        public void AddGoodsComment(string com, int userid, int goodsid, DateTime datetime, int num)
        {
            igc.AddGoodsComment(com,userid,goodsid,datetime,num);
        }
    }
}
