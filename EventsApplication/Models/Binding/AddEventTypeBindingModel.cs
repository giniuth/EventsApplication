using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Models.Binding
{
    public class AddEventTypeBindingModel
    {

        public int ID { get; set; }
        public string OccasionName{ get; set; }
        public int Budget { get; set; }
        public Size CakeSize { get; set; }
        public string PictureURL { get; set; }
        
    }
}
