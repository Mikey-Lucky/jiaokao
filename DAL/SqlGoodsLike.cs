using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlGoodsLike:IGoodsLike
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void GoodsLikeClick(int userid, int goodsid)
        {
            GoodsLike like = db.GoodsLike.Where(u => u.UserID == userid &&u.GoodsID == goodsid).FirstOrDefault();
            if (like != null)
            {
                db.GoodsLike.Remove(like);
                db.SaveChanges();
            }
            else
            {
                GoodsLike like1 = new GoodsLike();
                like1.GoodsID = goodsid;
                like1.UserID = userid;
                like1.ThumbTime = DateTime.Now;
                db.GoodsLike.Add(like1);
                db.SaveChanges();
            }
        }
        public int goodslikenum(int goodsid)
        {
            int likenum = db.GoodsLike.Where(g=>g.GoodsID==goodsid).Count();
            var t = db.Goods.Where(g => g.GoodsID == goodsid).FirstOrDefault();
            t.ThumbNum = likenum;
            db.SaveChanges();
            return likenum;
        }
    }
}
