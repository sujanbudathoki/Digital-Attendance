using MyAttendance.Models.Attendance;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Services
{
    public class ReportService : IReportService
    {
        IRepository<StudentAttend> _attendContext;
        public ReportService(IRepository<StudentAttend> _attendContext)
        {
            this._attendContext = _attendContext;
        }
        public List<StudentAttend> GetStudentAttends(int flag)
        {
            var studentReport = new List<StudentAttend>();
            if (flag == 1)//today
            {
                studentReport = _attendContext.Collection()
                    .Where(x => x.CurrentDate == DateTime.Now.Date)
                    .ToList();
                return studentReport;
                    
            }
            else if(flag==2)//yesterday
            {
                studentReport = _attendContext.Collection()
                    .Where(x => x.CurrentDate == DateTime.Now.AddDays(-1))
                    .ToList();
            }
            return studentReport;
        }
    }
}