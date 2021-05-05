using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Models
{
    //because we work with entities I need to give it an ID
    public class EventType
    {
        public int ID { get; set; }
        [DisplayName("Occasion Name")]
        public string OccasionName { get; set; }
        public int Budget { get; set; }
        [DisplayName("Inspo Pictures")]
        public string PictureURL { get; set; }
        [DisplayName("Cake Size")]
        public Size CakeSize { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual List<DecorDetail> DecorDetails { get; set; }

    }
    public enum Size
    {
        Small = 1,
        Medium,
        Large

    }
}
