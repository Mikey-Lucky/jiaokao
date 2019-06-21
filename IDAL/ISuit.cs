using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface ISuit
    {
        //通过季节找套装
        IQueryable<Suit> SuitBySeason(string season,int userid);
        //通过气温查找套装
        IQueryable<Suit> SuitByTemp(int temp,int userid);
        //添加套装
        void AddSuit(Suit suit);
        //根据id删除套装
        void DeleteSuitById(int id);

    }
}
