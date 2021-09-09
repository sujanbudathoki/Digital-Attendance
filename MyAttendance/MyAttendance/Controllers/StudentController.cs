using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        IStudentService _stdService;
        IRepository<Student> _studentService;
        public StudentController(IStudentService _stdService,IRepository<Student> _studentService)
        {
            this._stdService = _stdService;
            this._studentService = _studentService;
        }

        public ActionResult Index()
        {
            var classList =
                _stdService.GetClassStudentViewModels()
                           .Select(x=>_stdService.GetStandards().Where(y=>y.Id==x.classId).FirstOrDefault());


            return View(classList);
        }


        public ActionResult StudentIndex(int Id)
        {

            string className =
                _stdService.getClassName(Id);

            var studentList =
                _stdService.GetClassStudentViewModels()
                                          .Where(x => x.classId == Id)
                                          .Select(x => x.students)
                                          .FirstOrDefault()
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
                students = studentList,
                ClassId = Id
            };
            return View(studentIndex);

        }


        public ActionResult Create(int Id)
        {
            // ViewBag.Standards = _stdService.GetStandards();
            string className =
                _stdService.getClassName(Id);

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
                return RedirectToAction("StudentIndex", "Student", new { @id = model.ClassId });
            }
        }

        public ActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var student = _studentService.Collection().Where(x => x.Id == Id).FirstOrDefault();
                return View(student);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Student model)
        {
            _studentService.Delete(model.Id);
            _studentService.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var model = _studentService.Collection().Where(x => x.Id == Id).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            else
            {
                _studentService.Edit(student);
                _studentService.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}