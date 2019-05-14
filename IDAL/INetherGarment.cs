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
    }
}
