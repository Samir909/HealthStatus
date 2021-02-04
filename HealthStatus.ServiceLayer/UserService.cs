using HealthStatus.ViewModels;
using HealthStatus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthStatus.DomainModels;

namespace HealthStatus.ServiceLayer
{
    public interface IUserService
    {
        void InsertUser(UserModel user);
        User GetUsersByEmailAndPassword(string Email, string Password);

        void InsertStatus(Status status);

        IEnumerable<StatusShow> UserList();


    }
   public class UserService : IUserService
    {
        IUserRepository ur;
        public UserService()
        {
            ur= new UserRepository();
        }

        public void InsertUser(UserModel user)
        {
            ur.InsertUser(user);

        }

        public User GetUsersByEmailAndPassword(string Email, string Password)
        {

            User u = ur.GetUsersByEmailAndPassword(Email, Password).FirstOrDefault();
            return u;
        }

        public void InsertStatus(Status status)
        {
            ur.InsertStatus(status);
        }

       public IEnumerable<StatusShow> UserList()
        {
            IEnumerable<StatusShow> userListShow= ur.GetUsers();
            return userListShow;
        }
    }
}
