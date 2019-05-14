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
        IQueryable<Shirt> ShirtBySeason(string season);
    }
}
