﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IGoods
    {
        //查找销量前几的商品
        IEnumerable<Goods> GetHotGoods(int top);
        //查找最新上架商品
        IEnumerable<Goods> GetNewGoods(int top);
    }
}