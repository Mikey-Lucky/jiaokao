using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using 精致的衣橱.Models;


namespace 精致的衣橱.Controllers
{
    public class YiChuController : Controller
    {
        SuitManager suits = new SuitManager();
        CoatManager coats = new CoatManager();
        NetherGarmentManager nethers = new NetherGarmentManager();
        ShirtManager shirts = new ShirtManager();
        // GET: YiChu
        public ActionResult Index()
        {
            YiChuViewModel yichuview = new YiChuViewModel();
            int temp=12;//需获取前台值
            yichuview.springsuit = suits.ShirtBySeason("春季");
            yichuview.summersuit = suits.ShirtBySeason("夏季");
            yichuview.autumnsuit = suits.ShirtBySeason("秋季");
            yichuview.wintersuit = suits.ShirtBySeason("冬季");
            yichuview.springcoat = coats.CoatBySeason("春季");
            yichuview.summercoat = coats.CoatBySeason("夏季");
            yichuview.autumncoat = coats.CoatBySeason("秋季");
            yichuview.wintercoat = coats.CoatBySeason("冬季");
            yichuview.springnethergarment = nethers.NetherBySeason("春季");
            yichuview.summernethergarment = nethers.NetherBySeason("夏季");
            yichuview.autumnnethergarment = nethers.NetherBySeason("秋季");
            yichuview.winternethergarment = nethers.NetherBySeason("冬季");
            yichuview.springshirt = shirts.ShirtBySeason("春季");
            yichuview.summershirt = shirts.ShirtBySeason("夏季");
            yichuview.autumnshirt = shirts.ShirtBySeason("秋季");
            yichuview.wintershirt = shirts.ShirtBySeason("冬季");
            yichuview.nethergarmentbytemp = nethers.NetherGarmentByTemp(temp);
            yichuview.shirtbytemp = shirts.ShirtByTemp(temp);
            yichuview.coatbytemp = coats.CoatByTemp(temp);
            yichuview.suitbytemp = suits.SuitByTemp(temp);
            return View(yichuview);
        }
    }
}