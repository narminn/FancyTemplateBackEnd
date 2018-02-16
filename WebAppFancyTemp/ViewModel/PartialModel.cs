using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppFancyTemp.Models;

namespace WebAppFancyTemp.ViewModel
{
    public class PartialModel
    {
        public List<Contact> _contact { get; set; }
        public List<Category> _category { get; set; }
        public List<Menu> _menu { get; set; }
    }
}