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
        FancyTempDBEntities db = new FancyTempDBEntities();
        public View_Model vm = new View_Model();
        public ActionResult Index()
        {
            vm._blog = db.Blogs.Take(3).ToList();
            vm._feature = db.Feature_Boxes.Take(3).ToList();
            vm._industry = db.Industries.Take(1).ToList();
            vm._service = db.Service_Area.Take(1).ToList();
            vm._service_content = db.Service_Area_Contents.Take(3).ToList();
            vm._testimonial = db.Testimonials_Slider.Take(3).ToList();
            vm._slider = db.Sliders.Take(1).ToList();
            return View(vm);
        }

        
    }
}