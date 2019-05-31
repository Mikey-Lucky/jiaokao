using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlGoodsComment:IGoodsComment
    {
        yichuEntities db = new yichuEntities();
        public IEnumerable<GoodsComment> Getgoodscomment()
        {
            var goodscomment = db.GoodsComment.ToList();
            return goodscomment;
        }
        public IEnumerable<GoodsComment> Getgoodscommentbyid(int? id)
        {
            var goodscomment = db.GoodsComment.Where(u => u.GoodsID == id).OrderByDescending(u=>u.ComTime);
            return goodscomment;
        }
        public void AddGoodsComment(string com,int userid,int goodsid,DateTime datetime,int num)
        {
            //db.GoodsComment.Add(goodscomment);
            //db.SaveChanges();
            var Comment = new GoodsComment()
            {
                ComContent = com,
                UserID = userid,
                GoodsID = goodsid,
                ComTime = datetime,
                ThumbNum = num
            };
            db.GoodsComment.Add(Comment);
            db.SaveChanges();
        }

    }
}
