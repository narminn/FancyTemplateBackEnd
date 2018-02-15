using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppFancyTemp.Models
{
    public class Check
    {
        public static bool Check_Login()
        {
            if (HttpContext.Current.Session["User_email"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}