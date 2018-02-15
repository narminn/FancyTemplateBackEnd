using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppFancyTemp.Models;

namespace WebAppFancyTemp.Controllers
{
    public class BlogsController : Controller
    {
        private FancyTempDBEntities db = new FancyTempDBEntities();

        // GET: Blogs
        public ActionResult Index()
        {
            if (Check.Check_Login())
            {
                var blogs = db.Blogs.Include(b => b.Category);
                return View(blogs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (Check.Check_Login())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Blog blog = db.Blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                return View(blog);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            if (Check.Check_Login())
            {
                ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "blog_id,blog_title,blog_content,blog_img,blog_category_id")] Blog blog, HttpPostedFileBase blog_img)
        {
            if (Check.Check_Login())
            {
                if (ModelState.IsValid)
                {
                    var file_name = Path.GetFileName(blog_img.FileName);
                    if (blog_img.ContentLength > 0)
                    {

                        var file_src = Path.Combine(Server.MapPath("/Uploads"), file_name);
                        blog_img.SaveAs(file_src);
                    }
                    blog.blog_img = file_name;
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
                return View(blog);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Check.Check_Login())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Blog blog = db.Blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
                return View(blog);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "blog_id,blog_title,blog_content,blog_img,blog_category_id")] Blog blog)
        {
            if (Check.Check_Login())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(blog).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.blog_category_id = new SelectList(db.Categories, "category_id", "category_name", blog.blog_category_id);
                return View(blog);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Check.Check_Login())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Blog blog = db.Blogs.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                return View(blog);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Check.Check_Login())
            {
                Blog blog = db.Blogs.Find(id);
                db.Blogs.Remove(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
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
