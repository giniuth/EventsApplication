using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Models.Binding
{
    public class AddDecorDetailBindingModel
    {
        public int GuestCapacity { get; set; }
        public string Description { get; set; }
        public string Alcohol { get; set; }
        public string Catering { get; set; }
        public string Cuisine { get; set; }

        public int EventTypeID { get; set; }
    }
}
