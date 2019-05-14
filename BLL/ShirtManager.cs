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
    }
}
