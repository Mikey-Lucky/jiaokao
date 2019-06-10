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
    public class ComRepliesController : Controller
    {
        private yichuEntities db = new yichuEntities();

        // GET: ComReplies
        public ActionResult Index()
        {
            var comReply = db.ComReply.Include(c => c.GoodsComment).Include(c => c.Users);
            return View(comReply.ToList());
        }

        // GET: ComReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComReply comReply = db.ComReply.Find(id);
            if (comReply == null)
            {
                return HttpNotFound();
            }
            return View(comReply);
        }

        // GET: ComReplies/Create
        public ActionResult Create()
        {
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComment, "GoodsCommentID", "ComContent");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password");
            return View();
        }

        // POST: ComReplies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComReplyID,UserID,GoodsCommentID,RepContent,RepTime")] ComReply comReply)
        {
            if (ModelState.IsValid)
            {
                db.ComReply.Add(comReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsCommentID = new SelectList(db.GoodsComment, "GoodsCommentID", "ComContent", comReply.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", comReply.UserID);
            return View(comReply);
        }

        // GET: ComReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComReply comReply = db.ComReply.Find(id);
            if (comReply == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComment, "GoodsCommentID", "ComContent", comReply.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", comReply.UserID);
            return View(comReply);
        }

        // POST: ComReplies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComReplyID,UserID,GoodsCommentID,RepContent,RepTime")] ComReply comReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComment, "GoodsCommentID", "ComContent", comReply.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Password", comReply.UserID);
            return View(comReply);
        }

        // GET: ComReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComReply comReply = db.ComReply.Find(id);
            if (comReply == null)
            {
                return HttpNotFound();
            }
            return View(comReply);
        }

        // POST: ComReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComReply comReply = db.ComReply.Find(id);
            db.ComReply.Remove(comReply);
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
