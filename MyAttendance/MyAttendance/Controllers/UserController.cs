using MyAttendance.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MyAttendance.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            FormsAuthentication.SetAuthCookie(model.Email, false);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult RegisterAsTeacher()
        {
            return View();
        }
        public ActionResult RegisterAsStudent()
        {
            return View();
        }

    }
}