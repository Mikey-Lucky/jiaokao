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
    public class NetherGarmentManager
    {
         INetherGarment inether = DataAccess.CreateNetherGarment();
        //通过季节查询下装
        public IQueryable<NetherGarment> NetherBySeason(string season,int userid)
        {
            var nether = inether.NetherGarmentBySeason(season,userid);
            return nether;
        }
        //通过温度找下装
        public IQueryable<NetherGarment> NetherGarmentByTemp(int temp,int userid)
        {
            return inether.NetherGarmentByTemp(temp,userid);
        }
        //添加下衣
        public void AddNether(NetherGarment nether)
        {
            inether.AddNether(nether);
        }
        //查找与某颜色上衣相配的下衣
        public IQueryable<NetherGarment> NetherBaiDa(string season, string color)
        {
            return inether.NetherBaiDa(season, color);
        }
        public void DeleteNeById(int id)
        {
            inether.DeleteNeById(id);
        }
    }
}
