using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IShirt
    {
        //根据季节找出上衣
        IQueryable<Shirt> ShirtBySeason(string season,int userid);
        //根据温度找上衣
        IQueryable<Shirt> ShirtByTemp(int temp, int userid);
        //添加上衣
        void AddShirt(Shirt shirt);
        //更具id查找上衣
        Shirt GetShirtById(int id);
        //根据id删除上衣
        void DeleteShirtById(int id);
        //更新上衣
        void UpdateShirt(Shirt shirt);
    }
}
