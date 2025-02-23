using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurfBooking.BusinessLayer.Model
{
    public class Turf
    {
        [Key]
        public int TurfId { get; set; }

        public string Location { get; set; }
        public bool Availability { get; set; }
    }
}
