using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Models
{
    public class DecorDetail
    {
        public int ID { get; set; }
        [DisplayName("Guest Capacity")]
        public int GuestCapacity { get; set; }
        public string Description { get; set; }
        public string Alcohol { get; set; }
        public string Catering { get; set; }
        public string Cuisine { get; set; }

        public virtual EventType EventType { get; set; }

    }
}
