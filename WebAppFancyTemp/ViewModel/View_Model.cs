using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppFancyTemp.Models;
namespace WebAppFancyTemp.ViewModel
{
    public class View_Model
    {
        
        public IEnumerable<Blog> _blog { get; set; }
        public IEnumerable<Feature_Boxes> _feature{ get; set; }
        public IEnumerable<Industry> _industry { get; set; }
        public IEnumerable<Service_Area> _service { get; set; }
        public IEnumerable<Service_Area_Contents> _service_content { get; set; }
        public IEnumerable<Testimonials_Slider> _testimonial { get; set; }
        public IEnumerable<Slider> _slider { get; set; }
    }
}