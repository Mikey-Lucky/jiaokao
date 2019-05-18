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
        public IQueryable<Shirt> ShirtBySeason(string season)
        {
            var shirt = ishirt.ShirtBySeason(season);
            return shirt;
        }
        //通过气温查询上衣
        public IQueryable<Shirt> ShirtByTemp(int temp) {
            return ishirt.ShirtByTemp(temp);
        }
        //添加上衣
        public void AddShirt(Shirt shirt)
        {
            ishirt.AddShirt(shirt);
        }
    }
}
