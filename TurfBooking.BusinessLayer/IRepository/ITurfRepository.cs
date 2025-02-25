using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.BusinessLayer.IRepository
{
    public interface ITurfRepository
    {
        IEnumerable<Turf> GetAllTurf();
    }
}
