using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ICoat
    {
        //通过季节找外套
        IQueryable<Coat> CoatBySeason(string season);
        //通过温度找外套
        IQueryable<Coat> CoatByTemp(int temp);
    }
}
