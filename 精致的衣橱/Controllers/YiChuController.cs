using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
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
            /* var temp = Convert.ToInt32(context.Request["weather"]);*///数据获取失败
            int temp = 12;//需获取前台值
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
        //GET上传衣服
        public ActionResult AddClothes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClothes(FormCollection col)
        {
            Suit suit = new Suit();
            Coat coat = new Coat();
            NetherGarment ne = new NetherGarment();
            Shirt shirt = new Shirt();

            string color = col["color"];            string yizong = col["yifu"];            string season = col["season"];            string material = col["material"];            var img = Request.Files["imgFile"];            string path = Guid.NewGuid().ToString() + img.FileName;            switch (yizong)            {                case "衬衫":                case "连帽卫衣":                case "圆领卫衣":                case "T恤":                case "吊带":                    shirt.Color = color;                    shirt.Design = yizong;                    shirt.Image = "../shirt/" + path;                    shirt.Material = material;                    shirt.Season = season;                    shirt.Time = DateTime.Now;                    shirt.WardrobeID = 1;                    shirts.AddShirt(shirt);                    img.SaveAs(Request.MapPath("/Images/shirt/" + path));

                    break;                case "棒球服":                case "风衣":                case "针织开衫":                case "牛仔":
                    coat.Color = color;
                    coat.Design = yizong;
                    coat.Image = "../Coat/" + path;
                    coat.Material = material;
                    coat.Season = season;
                    coat.Time = DateTime.Now;
                    coat.WardrobeID = 1;
                    coats.AddCoat(coat);                    img.SaveAs(Request.MapPath("/Images/Coat/" + path));                    break;                case "超短裤":                case "短裤":                case "中长裙":                case "长裤":
                    ne.Color = color;
                    ne.Design = yizong;
                    ne.Image = "../NetherGarment/" + path;
                    ne.Material = material;
                    ne.Season = season;
                    ne.Time = DateTime.Now;
                    ne.WardrobeID = 1;
                    nethers.AddNether(ne);                    img.SaveAs(Request.MapPath("/Images/NetherGarment/" + path));                    break;                case "套装":
                    suit.Color = color;
                    suit.Design = yizong;
                    suit.Image = "../Suit/" + path;
                    suit.Material = material;
                    suit.Season = season;
                    suit.Time = DateTime.Now;
                    suit.WardrobeID = 1;
                    suits.AddSuit(suit);                    img.SaveAs(Request.MapPath("/Images/Suit/" + path));                    break;            }
            return Content(color + path);
        }
    }
}