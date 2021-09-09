using MyAttendance.Models.Attendance;
using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        IRepository<Standard> _stdContext;
        IStudentService studentService;
        IRepository<Date> _dateContext;
        IRepository<AttendanceStatus> _attendContext;
        IRepository<StudentAttend> _studentAttendContext;
        public AttendanceController(IRepository<Standard> _stdContext, IStudentService studentService,IRepository<Date> _dateContext,IRepository<AttendanceStatus> _attendContext,IRepository<StudentAttend> _studentAttendContext)
        {
            this._stdContext = _stdContext;
            this.studentService = studentService;
            this._dateContext = _dateContext;
            this._attendContext = _attendContext;
            this._studentAttendContext = _studentAttendContext;

        }

        // GET: Attendace

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TakeAttendanceIndex()
        {
            var standardList =
                _stdContext.Collection();
            return View(standardList);
        }

        public ActionResult TakeAttendance(int classId)
        {
            Date dateModel = _dateContext.Collection().Where(x=>x.date==DateTime.Now.Date).FirstOrDefault();
            if (dateModel != null)
            {
                if (dateModel.isHolidayFlag==1)
                {
                    
                    TempData["ErrorMessage"] = 1;
                    TempData.Keep();
                    return RedirectToAction("TakeAttendanceIndex");
                }
                else 
                {
                    bool alreadyAttend = _attendContext.Collection().Any(x => x.DateId == dateModel.Id&&x.ClassId==classId);
                    if (alreadyAttend)
                    {
                      
                        TempData["ErrorMessage"] = 2;
                        TempData.Keep();
                        return RedirectToAction("TakeAttendanceIndex");
                    }
                    else
                    {
                        TempData.Clear();
                        var ClassData =
                            _stdContext.Collection()
                                       .Where(x => x.Id == classId)
                                       .FirstOrDefault();

                        var attendStandard = studentService.GetClassStudentViewModels()
                                                           .Where(x => x.classId == classId)
                                                           .Select(y => y.students)
                                                           .FirstOrDefault()
                                                           .Select(z => new StudentAttendView()
                                                           {
                                                               Id = z.Id,
                                                               StudentName = z.StudentName,
                                                               ClassId = z.ClassId,
                                                               ClassName = ClassData.StandardName,
                                                               Roll = z.Roll,
                                                               DateId = dateModel.Id


                                                           }).ToList();


                        ViewBag.ClassName = ClassData.StandardName;
                        ViewBag.Count = attendStandard.Count;
                        return View(new StudentForm()
                        { students = attendStandard });
                    }
                }
            }
            else
            {
                TempData["Error"]= "Please , Register Today as working day or holiday";
                TempData.Keep();
                return RedirectToAction("RegisterToday","Date");
               

            }
        }

        [HttpPost]
        public ActionResult TakeAttendance(StudentForm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                 
                foreach(var item in model.students)
                {
                    var attendModel = new StudentAttend()
                    {
                        StudentId = item.Id,
                        CurrentDate = DateTime.Now.Date,
                        dateId = item.DateId,
                        presentFlag = item.isPresent == true ? 1 : 2
                    };
                    _studentAttendContext.Insert(attendModel);
                }
                 _studentAttendContext.Commit();

                 var attendStatus = new AttendanceStatus()
                  {
                    ClassId = model.students.FirstOrDefault().ClassId,
                    DateId = model.students.FirstOrDefault().DateId,
                    IsAttendanceCompleteFlag = 1
                  };
                
                _attendContext.Insert(attendStatus);
                _attendContext.Commit();
                 return View();
            }

        }
        public ActionResult Redraft()
        {
            var standardList =
               _stdContext.Collection();
            return View(standardList);
            
        }
        public ActionResult EditAttendance(int classId)
        {
            var date = _dateContext.Collection().Where(x => x.date.Date == DateTime.Now.Date).FirstOrDefault();
            return View(date);
        }
    }
}