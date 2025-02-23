using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.BusinessLayer.IRepository
{
    public interface IUserRepository
    {
        public int Create(User user);
        public int Update(User user);
        public int Delete(int userId);
        public User GetById(int userId);
        public List<User> GetAllUser();
    }
}
