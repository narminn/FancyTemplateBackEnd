using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFancyTemp.Models;
namespace WebAppFancyTemp.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        public ActionResult Index()
        {
            if (Check.Check_Login())
            {
                return View();
                
            }
            else
            {
               return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Tables()
        {
            if (Check.Check_Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}