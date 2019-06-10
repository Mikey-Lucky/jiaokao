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
    public class GoodsIndexController : Controller
    {
        private yichuEntities db = new yichuEntities();

        // GET: GoodsIndex
        public ActionResult Index()
        {
            return View(db.Goods.ToList());
        }

        // GET: GoodsIndex/Details/5
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

        // GET: GoodsIndex/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoodsIndex/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsID,Name,Sex,Season,Material,Style,GoodsImage,Amount,Unitprice,Type,SizeImage,ShangjiaTime,Pageview,TotalStorageAmount,ThumbNum")] Goods goods)
        {
            var goodsimage = Request.Files["goodsimage"];
            var imagepath =  goodsimage.FileName;
            goodsimage.SaveAs(Request.MapPath("/Images/GoodsImages/" + imagepath));

            if (goodsimage != null)
                {
                //string filePath = goodsimage.FileName;
                //string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                //string serverpath = Server.MapPath(@"\..\GoodsImages\") + filename;
                //string relativepath = "../GoodsImages/" + goodsimage;
                //goodsimage.SaveAs(serverpath);
                //goods.GoodsImage = relativepath;
                goods.GoodsImage = "../GoodsImages/" + imagepath;
                //var imgfile = Request.Files["imgfile"];
                //var title = Request["title"];
                //var notecontent = Request["content"];
                //var imgpath = Guid.NewGuid().ToString() + imgfile.FileName;
                //imgfile.SaveAs(Request.MapPath("/Images/Noteimg/" + imgpath));
                //note.Title = title;
                //note.NoteContent = notecontent;
                //note.likenum = 0;
                //note.Time = DateTime.Now;
                //note.Img = "../Noteimg/" + imgpath;
                //note.UserID = 1;
                //notes.AddNote(note);
                //return View();

            }
                //else
                //{
                //    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                //}
                db.Goods.Add(goods);
                db.SaveChanges();
            //return RedirectToAction("Index");
            return Content("<script>;alert('添加成功');window.location.href='../GoodsIndex/Index'</script>");
            

            //return View(goods);
        }

        // GET: GoodsIndex/Edit/5
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

        // POST: GoodsIndex/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsID,Name,Sex,Season,Material,Style,GoodsImage,Amount,Unitprice,Type,SizeImage,ShangjiaTime,Pageview,TotalStorageAmount,ThumbNum")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(goods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        // GET: GoodsIndex/Delete/5
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

        // POST: GoodsIndex/Delete/5
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
