using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppFancyTemp.Models;

namespace WebAppFancyTemp.Controllers
{
    public class Feature_BoxesController : Controller
    {
        private FancyTempDBEntities db = new FancyTempDBEntities();

        // GET: Feature_Boxes
        public ActionResult Index()
        {
            return View(db.Feature_Boxes.ToList());
        }

        // GET: Feature_Boxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Boxes feature_Boxes = db.Feature_Boxes.Find(id);
            if (feature_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(feature_Boxes);
        }

        // GET: Feature_Boxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feature_Boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feature_boxes_id,feature_boxes_title,feature_boxes_icon,feature_boxes_content,feature_boxes_url")] Feature_Boxes feature_Boxes)
        {
            if (ModelState.IsValid)
            {
                db.Feature_Boxes.Add(feature_Boxes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feature_Boxes);
        }

        // GET: Feature_Boxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Boxes feature_Boxes = db.Feature_Boxes.Find(id);
            if (feature_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(feature_Boxes);
        }

        // POST: Feature_Boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feature_boxes_id,feature_boxes_title,feature_boxes_icon,feature_boxes_content,feature_boxes_url")] Feature_Boxes feature_Boxes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feature_Boxes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feature_Boxes);
        }

        // GET: Feature_Boxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Boxes feature_Boxes = db.Feature_Boxes.Find(id);
            if (feature_Boxes == null)
            {
                return HttpNotFound();
            }
            return View(feature_Boxes);
        }

        // POST: Feature_Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feature_Boxes feature_Boxes = db.Feature_Boxes.Find(id);
            db.Feature_Boxes.Remove(feature_Boxes);
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
