using MyAttendance.Models.Components;
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
            var classList = _stdService.GetClassStudentViewModels()
                                       .Select(x => x.classId);

            return View(classList);
        }

        public ActionResult StudentIndex(int Id)
        {

            string className = _stdService.getClassName(Id);
            var studentList  = _stdService.GetClassStudentViewModels()
                                          .Where(x => x.classId == Id)
                                          .Select(x => x.students).FirstOrDefault()
                                          .Select(y =>
                                           new StudentView()
                                           {
                                              Id = y.Id,
                                              Name = y.StudentName,
                                              Class = className,
                                              Roll = y.Roll
                                           }).ToList();
            var studentIndex = new StudentMain() 
            { 
                Class = className,
                students = studentList ,
                ClassId = Id
            };
           return View(studentIndex);
                     
        }
        public ActionResult Create(int Id)
        {
            // ViewBag.Standards = _stdService.GetStandards();
            string className = _stdService.getClassName(Id);
            var model = new StudentView()
            {
                Class = className,
                ClassId = Id
            };
            return View(model);
        }
       
        [HttpPost]
        public ActionResult Create(StudentView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var studentModel = new Student()
                {
                    StudentName = model.Name,
                    ClassId = model.ClassId,
                    Roll = model.Roll
                };
                _stdService.InsertStudent(studentModel);
                return RedirectToAction("StudentIndex","Student",new { @id=model.ClassId});
            }
        }

    }
}