using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INetherGarment
    {
        //通过季节找下衣
        IQueryable<NetherGarment> NetherGarmentBySeason(string season);
        //通过温度找下衣
        IQueryable<NetherGarment> NetherGarmentByTemp(int temp);
        //添加下衣
        void AddNether(NetherGarment nether);
        //可以与某颜色上单衣搭配的下衣，传入季节和颜色参数
        IQueryable<NetherGarment> NetherBaiDa(string season, string color);

    }
}
