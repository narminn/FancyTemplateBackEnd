using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppFancyTemp.Models;
namespace WebAppFancyTemp.ViewModel
{
    public class Home
    {
        
        public List<Blog> _blog { get; set; }
        public List<Feature_Boxes> _feature{ get; set; }
        public List<Industry> _industry { get; set; }
        public List<Service_Area> _service { get; set; }
        public List<Service_Area_Contents> _service_content { get; set; }
        public List<Testimonials_Slider> _testimonial { get; set; }
        public List<Slider> _slider { get; set; }
        public List<Blog> _blog_feature { get; set; }
        
    }
}