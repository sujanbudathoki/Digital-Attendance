using MyAttendance.Helpers;
using MyAttendance.Models;
using MyAttendance.Models.User;
using MyAttendance.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MyAttendance.Controllers
{
    public class UserController : Controller
    {
        IRepository<UserModel> _userContext;
        public UserController(IRepository<UserModel> _userContext)
        {
            this._userContext = _userContext;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
           

                bool checkUser = _userContext.Collection().Any(x => x.Email == model.Email && x.Password == model.Password);
                if (checkUser)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "*Invalid credentials. Please try again.";
                    return View();

                }
            
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult SignUp()
        {
            //ViewBag.Gender = Components.getGender();
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (model != null)
                {
                    model.UserTypeId = 1; //manually setting role to teacher
                    _userContext.Insert(model);
                    _userContext.Commit();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "*Missing Elements";
                    return View();
                }
            }
        }
      

    }
}