
using HealthStatus.ViewModels;
using HealthStatus.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthStatus.DomainModels;

namespace HealthStatus.Controllers
{
    public class UserController : Controller
    {
        // GET: User
       private IUserService _us =null;


        public UserController(IUserService userService)
        {
            _us = userService;
        }

        public ActionResult Registration()
        {
           // HealthStatusDbContext db = new HealthStatusDbContext();
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel uvm)
         {
            if (ModelState.IsValid)
            {
               this._us.InsertUser(uvm);
            
            }
            return View();
   
        }
        [Route("")]
        public ActionResult Login()
        {

            User lvm = new User();

           
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel lvm)
        {

            
                User logIn = this._us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);

                if (logIn != null)
                {
                   

                    Session["CurrentUserID"] = logIn.ID;
                    Session["CurrentUserEmail"] = logIn.Email;
                    Session["CurrentUserPassword"] = logIn.Password;
                    Session["CurrentAdmin"] = logIn.IsAdmin;

                    if (logIn.Email != null && logIn.IsAdmin == 0)
                    {
                        return RedirectToAction("MainTask", "User");
                    }else if(logIn.Email != null && logIn.IsAdmin == 1)
                    {
                        return RedirectToAction("AdminLogin", "User");
                    }

                    else
                    {
                        ModelState.AddModelError("x", "Invalid Email / Password");
                        return View(logIn);
                    }
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Data");
                    return View(logIn);
                }


        }

        public ActionResult AdminLogin()
        {
            List<StatusShow> listOfUser = this._us.UserList().ToList();

            return View(listOfUser);
        }

        public ActionResult MainTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MainTask(Status s)
        {

            if (ModelState.IsValid)
            {
                this._us.InsertStatus(s);

            }
            return View();

        }
    }
}