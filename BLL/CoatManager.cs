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
        //增加衣服
        public void AddCoat(Coat coat)
        {
            icoat.AddCoat(coat);
        }
        //通过季节查询外套
        public IQueryable<Coat> CoatBySeason(string season,int userid)
        {
            var coat = icoat.CoatBySeason(season,userid);
            return coat;
        }
        //通过温度查询外套
        public IQueryable<Coat> CoatByTemp(int temp,int userid)
        {
            return icoat.CoatByTemp(temp,userid);
        }
        public void DeleteCoatById(int id)
        {
            icoat.DeleteCoatById(id);
        }
    }
}
