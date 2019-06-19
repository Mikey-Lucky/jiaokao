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
    public class ShirtManager
    {
        IShirt ishirt = DataAccess.CreateShirt();
        //通过季节查询上衣
        public IQueryable<Shirt> ShirtBySeason(string season,int userid)
        {
            var shirt = ishirt.ShirtBySeason(season,userid);
            return shirt;
        }
        //通过气温查询上衣
        public IQueryable<Shirt> ShirtByTemp(int temp,int userid) {
            return ishirt.ShirtByTemp(temp,userid);
        }
        //添加上衣
        public void AddShirt(Shirt shirt)
        {
            ishirt.AddShirt(shirt);
        }
        //更具id查找上衣
        public Shirt GetShirtById(int id)
        {
           return ishirt.GetShirtById(id);
        }
        //根据id删除上衣
        public void DeleteShirtById(int id)
        {
            ishirt.DeleteShirtById(id);
        }
        //更新上衣
        public void UpdateShirt(Shirt shirt)
        {
            ishirt.UpdateShirt(shirt);
        }
    }
}
