using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace 精致的衣橱.Controllers
{
    public class GoodsController : Controller
    {
        private yichuEntities db = new yichuEntities();

        // GET: Goods
        public ActionResult Index()
        {
            return View(db.Goods.ToList());
        }

        // GET: Goods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "GoodsID,Name,Sex,Season,Material,Style,GoodsImage,Amount,Unitprice,Type,SizeImage,ShangjiaTime,Pageview,TotalStorageAmount,ThumbNum")]
        public ActionResult Create(Goods goods)
        {
            var  goodsimage = Request.Files["imgfile"];
            var name = Request["name"].ToString();
            var sex = Request["sex"].ToString();
            var season = Request["season"].ToString();
            var material = Request["material"].ToString();
            var type = Request["type"].ToString();
            //var sex = Request["sex"].ToString();
            var time = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                if (goodsimage != null)
                {
                    goods.Name = name;
                    goods.Sex = sex;
                    goods.Season = season;
                    goods.Material = material;
                    goods.Type = type;
                    goods.ShangjiaTime = time;
                    string filePath = Guid.NewGuid().ToString() + goodsimage.FileName;
                    
                    
                   
                    goodsimage.SaveAs(Request.MapPath("/Images/GoodsImages/" + filePath));
                    goods.GoodsImage = "../GoodsImages/"+filePath;
                }
                db.Goods.Add(goods);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goods);
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsID,Name,Sex,Season,Material,Style,GoodsImage,Amount,Unitprice,Type,SizeImage,ShangjiaTime,Pageview,TotalStorageAmount,ThumbNum")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goods goods = db.Goods.Find(id);
            db.Goods.Remove(goods);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
