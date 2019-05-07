using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlGoods : IGoods
    {
        public IEnumerable<Goods> GetHotGoods()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Goods> GetNewGoods()
        {
            throw new NotImplementedException();
        }
    }
}
