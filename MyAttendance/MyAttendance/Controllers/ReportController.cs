using Microsoft.Ajax.Utilities;
using MyAttendance.Extensions;
using MyAttendance.Helpers;
using MyAttendance.Models.Attendance;
using MyAttendance.Models.Attendance.ViewModels;
using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        IRepository<StudentAttend> _studentAttendContext;
        IRepository<Student> _studentContext;
        IRepository<Standard> _standardContext;
        IRepository<Date> _dateContext;
       

        public ReportController(IRepository<StudentAttend> _studentAttendContext,IRepository<Student> _studentContext,IRepository<Standard> _standardContext,IRepository<Date> _dateContext)
        {
            this._studentAttendContext = _studentAttendContext;
            this._studentContext = _studentContext;
            this._standardContext = _standardContext;
            this._dateContext = _dateContext;
            
        }

        public ActionResult ReportIndex()
        {
            //check
            var studentAttendList = _studentAttendContext.Collection().ToList();
            var standardCollection = _standardContext.Collection().ToList();
            return View(standardCollection);
        }

        // GET: Report

        public ActionResult Index(int classId,bool isRefresh=true)
        {
            //To distinguish refresh and redirection
            if (isRefresh)
            {
                TempData.Clear();
            }

            ViewBag.Months = ComponentHelper.ReturnMonths();
           
            var model = _standardContext.Collection()
                .Where(x => x.Id == classId)
                .FirstOrDefault();
            return View(model);
        }


        public ActionResult getReport(int flag,int classId,int monthNo=0)
        {
            TempData.Clear();
            if (flag == 1)
            {
                ViewBag.ClassName = _standardContext.Collection()
                    .Where(x=>x.Id==classId)
                    .FirstOrDefault()
                    .StandardName;

                ViewBag.Date = DateTime.Now.ToShortDateString();

                ViewBag.ReportType = " [ Report Type - Single Day ] ";


                var date = _dateContext.Collection().Where(x => x.date == DateTime.Now.Date).FirstOrDefault();
              
                if (date != null)
                {

                    var studentReport =     (from s in _studentAttendContext.Collection()
                                             join j in _studentContext.Collection()
                                             on s.StudentId equals j.Id 
                                             where s.dateId == date.Id && j.ClassId==classId
                                             select new AttendanceContent()
                                             {
                                                 Name = j.StudentName,
                                                 AttendStatus = s.presentFlag == 2 ? "Absent" : "Present",
                                                 RollNo = j.Roll

                                             }).ToList();

                    if (studentReport.Count > 0)
                    {
                        return View(studentReport);
                    }
                    else
                    {
                        TempData["ErrorReference"] = 2;
                        /*2 represents date is registered but either student count of particular class is 0
                        or attendance of that particular class doesn't happen on that day */
                        return RedirectToAction("Index",new { @classId = classId, @isRefresh=false });

                    }

                   
                }
                else
                {
                    TempData["ErrorReference"] = date == null ? 1 : 0;
                    TempData.Keep();
                    //1 represents Date is not registered on that particular date

                    return RedirectToAction("Index",new { @classId = classId, @isRefresh=false });
                }

                
            }
            else if (flag == 2)
            {
                ViewBag.ClassName = _standardContext.Collection()
                   .Where(x => x.Id == classId)
                   .FirstOrDefault()
                   .StandardName;

                ViewBag.Date = DateTime.Now.AddDays(-1).ToShortDateString();

                ViewBag.ReportType = "[ Report Type - Single Day ]";

                var date = _dateContext.Collection().Where(x => x.date == DateTime.Now.AddDays(-1).Date).FirstOrDefault();
                if (date != null)
                {
                    var studentReport = ( from s in _studentAttendContext.Collection()
                                          join j in _studentContext.Collection()
                                          on s.StudentId equals j.Id
                                          where s.dateId == date.Id && j.ClassId == classId
                                          select new AttendanceContent()
                                          {
                                             Name = j.StudentName,
                                             AttendStatus = s.presentFlag == 2 ? "Absent" : "Present",
                                             RollNo = j.Roll

                                          }).ToList();

                    if (studentReport.Count >0)
                    {
                        return View(studentReport);
                    }
                    else
                    {
                        TempData["ErrorReference"] = 4;
                        TempData.Keep();
                        return RedirectToAction("Index",new { @classId = classId, @isRefresh=false });
                    }
                }
                else
                {
                    TempData["ErrorReference"] = 3;
                    TempData.Keep();
                    return RedirectToAction("Index",new { @classId = classId, @isRefresh=false });
                }

            }
          else if(flag == 3)
            {
                TempData["Class"] = _standardContext.Collection()
                  .Where(x => x.Id == classId)
                  .FirstOrDefault()
                  .StandardName;
                TempData["ReportType"] = " Report Type - Last 7 Days ";

                TempData["Month"]= ComponentHelper.GetMonth(DateTime.Now.Month);
                var date = (from s in _studentAttendContext.Collection()
                            join j in _studentContext.Collection()
                            on s.StudentId equals j.Id
                            where j.ClassId == classId && s.CurrentDate.IsInRange(DateTime.Now.AddDays(-7), DateTime.Now.Date)
                            select new DateNumber()
                            {

                               Date = s.CurrentDate.Day,
                               DateId=s.dateId
                               
                            }).DistinctBy(x=>x.Date).ToList();


                var users = (from s in _studentContext.Collection()
                             where s.ClassId == classId
                             select new AttendanceMultiDayUser()
                             {

                                 Name = s.StudentName,
                                 RollNo = s.Roll,
                                 Status = (from p in _studentAttendContext.Collection()
                                           join q in date
                                           on p.dateId equals q.DateId
                                           where p.StudentId==s.Id 
                                           orderby q.Date ascending 
                                           select p.presentFlag==1 ? "Present" : "Absent"
                                           ).ToList()
                             }).ToList();


                var model = new AttendanceMultiDayViewModel()
                {
                    ClassId=classId,
                    Studentlist = users,
                    DateNumber = date
                };
                TempData["StoreModel"] = model;
                TempData.Keep();

                return RedirectToAction("multiDateReport");
            }

            else if (flag == 4)
            {
                TempData["Class"] = _standardContext.Collection()
                  .Where(x => x.Id == classId)
                  .FirstOrDefault()
                  .StandardName;

                TempData["Month"] = ComponentHelper.GetMonth(DateTime.Now.Month);

                TempData["ReportType"] = "[ Report Type - Monthly ]";
                var date = (from s in _studentAttendContext.Collection()
                            join j in _studentContext.Collection()
                            on s.StudentId equals j.Id
                            where j.ClassId == classId && s.CurrentDate.Month == DateTime.Now.Month && s.CurrentDate.Year == DateTime.Now.Year
                            select new DateNumber()
                            {

                                Date = s.CurrentDate.Day,
                                DateId = s.dateId

                            }).DistinctBy(x => x.Date).ToList();


                    if (monthNo > 0)
                    {
                     date = (from s in _studentAttendContext.Collection()
                                join j in _studentContext.Collection()
                                on s.StudentId equals j.Id
                                where j.ClassId == classId && s.CurrentDate.Month == monthNo && s.CurrentDate.Year == DateTime.Now.Year
                                select new DateNumber()
                                {

                                    Date = s.CurrentDate.Day,
                                    DateId = s.dateId

                                }).DistinctBy(x => x.Date).ToList();
                     }
                



                var users = (from s in _studentContext.Collection()
                             where s.ClassId == classId
                             select new AttendanceMultiDayUser()
                             {
                                 Name = s.StudentName,
                                 RollNo = s.Roll,
                                 Status = (from p in _studentAttendContext.Collection()
                                           join q in date
                                           on p.dateId equals q.DateId
                                           where p.StudentId == s.Id
                                           orderby q.Date ascending
                                           select p.presentFlag == 1 ? "Present" : "Absent"
                                           ).ToList()
                             }).ToList();
                int max = users.Max(x => x.Status.Count);

                foreach(var user in users)
                {
                    if (user.Status.Count != max)
                    {
                       
                        int remaining = max - user.Status.Count;
                        for(int i = 0; i < remaining; i++)
                        {
                            user.Status.Add("N/a");
                        }
                        user.Status = user.Status.OrderByDescending(x => x).ToList();
                    }
                }

                var model = new AttendanceMultiDayViewModel()
                {
                    ClassId = classId,
                    Studentlist = users,
                    DateNumber = date
                };

                TempData["StoreModel"] = model;
                TempData.Keep();

                return RedirectToAction("multiDateReport");
            }
           
            
            return View();
        }

        public ActionResult multiDateReport()
        {
                ViewBag.ClassName = TempData["Class"];
                ViewBag.Date = TempData["Month"];
                ViewBag.ReportType = TempData["ReportType"];    
                var model = TempData["StoreModel"];
                return View(model);
           
        }

       
    }

}