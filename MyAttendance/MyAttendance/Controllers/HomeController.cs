using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}