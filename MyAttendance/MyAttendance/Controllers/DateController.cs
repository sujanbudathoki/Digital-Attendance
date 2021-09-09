using MyAttendance.Models.Attendance;
using MyAttendance.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class DateController : Controller
    {
        // GET: Date
        IRepository<Date> _dateContext;
        public DateController(IRepository<Date> _dateContext)
        {
            this._dateContext = _dateContext;
        }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult RegisterToday()
        {
            var todayDate = DateTime.Now;
            bool registerCheck = _dateContext.Collection().Any(x => x.date.Date == todayDate.Date);
            if (registerCheck)
            {
                return RedirectToAction("EditRegistrationIndex");
            }
            else
            {
                return View();
            }

        }
        
        [HttpPost]
        public ActionResult RegisterToday(Date dateModel)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                var model = new Date()
                {
                    date = DateTime.Now.Date,
                    isHolidayFlag = dateModel.isHolidayFlag
                };

                _dateContext.Insert(model);
                _dateContext.Commit();
                TempData.Clear();
                return RedirectToAction("Index", "Attendance");
            }

        }


        public ActionResult EditRegistrationIndex()
        {

            return View();
        }

        public ActionResult EditRegistration()
        {
            var model = _dateContext.Collection().Where(x => x.date == DateTime.Now.Date)
                                                 .FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditRegistration(Date date)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var datemodel = _dateContext.Collection().Where(x => x.date.Date == DateTime.Now.Date).FirstOrDefault();
                var model = new Date()
                {
                    Id = datemodel.Id,
                    date = datemodel.date,
                    isHolidayFlag = date.isHolidayFlag
                   
                };

                _dateContext.Detach(model);
                _dateContext.Edit(model);
                _dateContext.Commit();
                return RedirectToAction("Index", "Attendance");
            }
        }

        

      


       
    }
}