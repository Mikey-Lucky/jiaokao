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
        public IQueryable<NetherGarment> NetherBySeason(string season)
        {
            var nether = inether.NetherGarmentBySeason(season);
            return nether;
        }
        //通过温度找下装
        public IQueryable<NetherGarment> NetherGarmentByTemp(int temp)
        {
            return inether.NetherGarmentByTemp(temp);
        }
    }
}
