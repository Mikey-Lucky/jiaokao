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
    public class GoodsCommentsController : Controller
    {
        private yichuEntities db = new yichuEntities();

        // GET: GoodsComments
        public ActionResult Index()
        {
            var goodsComment = db.GoodsComment.Include(g => g.Goods).Include(g => g.Users);
            return View(goodsComment.ToList());
        }

        // GET: GoodsComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComment goodsComment = db.GoodsComment.Find(id);
            if (goodsComment == null)
            {
                return HttpNotFound();
            }
            return View(goodsComment);
        }

        // GET: GoodsComments/Create
        public ActionResult Create()
        {
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password");
            return View();
        }

        // POST: GoodsComments/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsCommentID,ComContent,ComImage,Video,ImageOrNot,VideoOrNot,UserID,GoodsID,ComTime,ThumbNum")] GoodsComment goodsComment)
        {
            if (ModelState.IsValid)
            {
                db.GoodsComment.Add(goodsComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "Name", goodsComment.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", goodsComment.UserID);
            return View(goodsComment);
        }

        // GET: GoodsComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComment goodsComment = db.GoodsComment.Find(id);
            if (goodsComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "Name", goodsComment.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", goodsComment.UserID);
            return View(goodsComment);
        }

        // POST: GoodsComments/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsCommentID,ComContent,ComImage,Video,ImageOrNot,VideoOrNot,UserID,GoodsID,ComTime,ThumbNum")] GoodsComment goodsComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodsComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "Name", goodsComment.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", goodsComment.UserID);
            return View(goodsComment);
        }

        // GET: GoodsComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComment goodsComment = db.GoodsComment.Find(id);
            if (goodsComment == null)
            {
                return HttpNotFound();
            }
            return View(goodsComment);
        }

        // POST: GoodsComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodsComment goodsComment = db.GoodsComment.Find(id);
            db.GoodsComment.Remove(goodsComment);
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
