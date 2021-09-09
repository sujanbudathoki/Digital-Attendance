using MyAttendance.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttendance.Repositories
{
  public  interface IReportService
    {
        List<StudentAttend> GetStudentAttends(int flag);
    }
}
