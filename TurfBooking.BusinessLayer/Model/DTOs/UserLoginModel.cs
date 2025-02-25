using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurfBooking.BusinessLayer.Model.DTOs
{
    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
