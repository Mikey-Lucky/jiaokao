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
    public class CoatManager
    {
        ICoat icoat = DataAccess.CreateCoat();
        //通过季节查询上衣
        public IQueryable<Coat> CoatBySeason(string season)
        {
            var coat = icoat.CoatBySeason(season);
            return coat;
        }
    }
}
