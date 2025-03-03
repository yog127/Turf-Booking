using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.BusinessLayer.IRepository
{
    public interface IAdminRepository
    {
        public int Create(Admin admin);
        public Admin GetByEmail(string email);
    }
}
