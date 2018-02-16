using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppFancyTemp.Models;
namespace WebAppFancyTemp.ViewModel
{
    public class BlogModel
    {
        public List<Blog> _blog_page { get; set; }
        public List<Blog> _blog { get; set; }
    }
}