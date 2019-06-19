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
        IQueryable<Coat> CoatBySeason(string season,int userid);
        //通过温度找外套
        IQueryable<Coat> CoatByTemp(int temp,int userid);
        //添加上衣
        void AddCoat(Coat coat);
    }
}
