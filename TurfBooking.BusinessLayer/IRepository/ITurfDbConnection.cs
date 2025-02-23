using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurfBooking.BusinessLayer.IRepository
{
    public interface ITurfDbConnection
    {
        public void Open();
        public void Close();
    }
}
