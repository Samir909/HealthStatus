using HealthStatus.DomainModels;
using HealthStatus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthStatus.Repositories
{
    public interface IUserRepository
    {
        void InsertUser(ViewModels.UserModel u);
        void InsertStatus(Status status);
        IEnumerable<StatusShow> GetUsers();

        List<User> GetUsersByEmailAndPassword(string Email, string Password);

    }
   public class UserRepository : IUserRepository
    {
        HealthStatusDbContext db;
        public UserRepository()
        {
            db = new HealthStatusDbContext();
        }

        public void InsertUser(ViewModels.UserModel u)
        {
         
            
            db.users.Add(new User() { Email=u.Email,Password=u.Password});
            db.SaveChanges();
        }

       public IEnumerable<StatusShow> GetUsers()
        {
            //db.users.Where(temp => temp.IsAdmin == 0).ToList();
          var us = (from u in db.users.AsEnumerable()
                    join st in db.statuses.AsEnumerable() on u.ID equals st.Uid
                    group u by new {u.Email,st.CurrentDate,st.CurrentStatus,st.Comments} into g
                    
                             select new StatusShow
                             {
                                 Email = g.Key.Email,
                                 Status = g.Key.CurrentStatus,
                                 Comments=g.Key.Comments,
                                 Date = g.Key.CurrentDate
                             })
                             .ToList();
            return us;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string Password)
        {
            List<User> us = db.users.Where(temp => temp.Email == Email && temp.Password == Password && temp.IsAdmin==0).ToList();
            List<User> admin = db.users.Where(temp => temp.Email == Email && temp.Password == Password && temp.IsAdmin==1).ToList();
            if (us.Count != 0)
            {
                return us;
            }
            else
            {
                return admin;
            }

            

        }


        public void InsertStatus(Status status)
        {
            //Status statusAndDate = db.statuses.Where(temp => temp.CurrentStatus != null || temp.CurrentStatus==null && temp.CurrentDate == status.CurrentDate &&temp.Uid==status.Uid ).FirstOrDefault();

            //if (statusAndDate.CurrentDate != null)
            //{
            //    statusAndDate.CurrentStatus = status.CurrentStatus;
            //     statusAndDate.CurrentDate=status.CurrentDate;
            //     statusAndDate.Comments=status.Comments;               
            //    db.SaveChanges();
            //}
            //else
            //{
            //    db.statuses.Add(status);
            //    db.SaveChanges();
            //}

            db.statuses.Add(status);
            db.SaveChanges();

        }
    }
}
