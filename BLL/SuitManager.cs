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
    public class SuitManager
    {
        ISuit isuit = DataAccess.CreateSuit();
        //通过季节查询套装
        public IQueryable<Suit> ShirtBySeason(string season)
        {
            var suit = isuit.SuitBySeason(season);
            return suit;
        }
        //通过气温查询套装
        public IQueryable<Suit> SuitByTemp(int temp)
        {
            return isuit.SuitByTemp(temp);
        }
    }
}
