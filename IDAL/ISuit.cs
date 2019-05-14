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
        IQueryable<Suit> SuitBySeason(string season);
    }
}
