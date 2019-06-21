using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlNetherGarment : INetherGarment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public void AddNether(NetherGarment nether)
        {
            db.NetherGarment.Add(nether);
            db.SaveChanges();
        }

      

        public IQueryable<NetherGarment> NetherGarmentBySeason(string season,int userid)
        {
            var nether = from n in db.NetherGarment
                        where n.Season == season&&n.Wardrobe.Userid==userid
                        select n;
            return nether;
        }

        public IQueryable<NetherGarment> NetherGarmentByTemp(int temp,int userid)
        {
            IQueryable<NetherGarment> nether;
            if (temp < 5)
            {
                nether = from c in db.NetherGarment
                       where c.Season == "冬季"&&c.Wardrobe.Userid==userid
                       select c;
            }
            else if (temp >= 5 && temp < 20)
            {
                nether = from c in db.NetherGarment
                       where (c.Season == "春季" || c.Season == "秋季") && c.Wardrobe.Userid == userid
                         select c;
            }
            else if (temp >= 20 && temp < 25)
            {
                nether = from c in db.NetherGarment
                       where (c.Season == "春季" || c.Season == "夏季") && c.Wardrobe.Userid == userid
                         select c;
            }
            else
            {
                nether = from c in db.NetherGarment
                       where c.Season == "夏季" && c.Wardrobe.Userid == userid
                         select c;
            }
            return nether;
        }
        public IQueryable<NetherGarment> NetherBaiDa(string season, string color)
        {
            IQueryable<NetherGarment> nether=null;
            switch (color)
            {
                case "白色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "黑色" || c.Color == "蓝色" || c.Color == "红色" || c.Color == "灰色" || c.Color == "棕色")
                             select c;
                    break;
                case "红色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "黑色" || c.Color == "白色")
                             select c;
                    break;
                case "米色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "黑色" || c.Color == "绿色" || c.Color == "蓝色")
                             select c;
                    break;
                case "黑色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "白色" || c.Color == "灰色")
                             select c;
                    break;
                case "黄色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "白色" || c.Color == "蓝色" || c.Color == "灰色" || c.Color == "黑色" || c.Color == "米色")
                             select c;
                    break;
                case "蓝色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "白色" || c.Color == "灰色" || c.Color == "红色" || c.Color == "棕色" || c.Color == "黑色")
                             select c;
                    break;
                case "橙色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "白色" || c.Color == "灰色" || c.Color == "黑色")
                             select c;
                    break;
                case "紫色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "白色" || c.Color == "灰色" || c.Color == "黑色")
                             select c;
                    break;
                case "灰色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "黑色" || c.Color == "白色" || c.Color == "棕色" || c.Color == "蓝色")
                             select c;
                    break;
                case "棕色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "米色" || c.Color == "黄色" || c.Color == "红色" || c.Color == "黑色")
                             select c;
                    break;
                case "绿色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "棕色" || c.Color == "白色" || c.Color == "米色" || c.Color == "黑色")
                             select c;
                    break;
                case "粉色":
                    nether = from c in db.NetherGarment
                             where c.Season == season && (c.Color == "紫色" || c.Color == "灰色" || c.Color == "白色" || c.Color == "米色" || c.Color == "棕色" || c.Color == "蓝色")
                             select c;
                    break;
                    //return nether;
            }
            return nether;
        }

        public void DeleteNeById(int id)
        {
            NetherGarment ne = db.NetherGarment.Where(s => s.NetherGarmentID == id).FirstOrDefault();
            if (ne != null)
            {
                db.NetherGarment.Remove(ne);
            }
            db.SaveChanges();
        }
    }
}
