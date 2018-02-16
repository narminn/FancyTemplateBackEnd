using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFancyTemp.Models;
using WebAppFancyTemp.ViewModel;
namespace WebAppFancyTemp.Controllers
{
    public class HomeController : Controller
    {
        public FancyTempDBEntities db = new FancyTempDBEntities();
        public Home vm = new Home();
        public PartialModel pm = new PartialModel();
        public BlogModel bm = new BlogModel();
        public ContactModel cm = new ContactModel();
        public ActionResult Index()
        {
            vm._blog = db.Blogs.Take(3).ToList();
            vm._feature = db.Feature_Boxes.Take(3).ToList();
            vm._industry = db.Industries.Take(1).ToList();
            vm._service = db.Service_Area.Take(1).ToList();
            vm._service_content = db.Service_Area_Contents.Take(3).ToList();
            vm._testimonial = db.Testimonials_Slider.Take(3).ToList();
            vm._slider = db.Sliders.Take(2).ToList();
            pm._category = db.Categories.ToList();
            pm._contact = db.Contacts.ToList();
            pm._menu = db.Menus.ToList();
            vm._blog_feature = db.Blogs.Take(1).ToList();
            
            return View(new HomeModel{partial=pm, view_model=vm });
        }
        public ActionResult Blog(int id)
        {
            pm._category = db.Categories.ToList();
            pm._menu = db.Menus.ToList();
            pm._contact = db.Contacts.ToList();
            bm._blog_page = db.Blogs.Where(b=>b.blog_id==id).ToList();
            bm._blog = db.Blogs.Take(3).ToList();
            
            return View(new BlogPartial {partial=pm, blog_model=bm});
        }
        public ActionResult Contact()
        {
            pm._category = db.Categories.ToList();
            pm._menu = db.Menus.ToList();
            pm._contact = db.Contacts.ToList();
            return View(new ContacPartial {partial=pm, contact_model=cm });
        }
        [HttpPost]
        public ActionResult Contact(FormCollection frm)
        {
            //Session["Email"] = frm["email"];
            //Session["Name"] = frm["name"];
            //Session["Content"] = frm["message"];
            //Session["MessageWebSite"] = frm["subject"];
            Message msg = new Message();
            msg.message_email = frm["email"];
            msg.message_name = frm["name"];
            msg.message_website_url = frm["subject"];
            msg.message_content = frm["message"];
            db.Messages.Add(msg);
            db.SaveChanges();
            return RedirectToAction("Index");                                                                                                                                                                                                                                                          

        }
        }
}