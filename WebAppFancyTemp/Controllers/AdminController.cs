using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppFancyTemp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            Session["User_email"] = frm["email"];
            Session["User_password"] = frm["password"];
            if (Session["User_email"].ToString()=="admin@gmail.com")
            {
                if (Session["User_password"].ToString() == "12345")
                {
                    return RedirectToAction("Index", "AdminPanel");
                }
                else
                {
                    ViewBag.Message = "password incorrect";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "email incorrect";
                return View();
            }
        }
    }
}