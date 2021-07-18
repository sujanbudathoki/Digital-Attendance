using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _stdService;
        public StudentController(IStudentService _stdService)
        {
            this._stdService = _stdService;
        }
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }
       

    }
}