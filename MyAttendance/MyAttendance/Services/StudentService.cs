using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using MyAttendance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Services
{
    public class StudentService : IStudentService
    {
        IRepository<Student> _studentContext;
        IRepository<Standard> _stdContext;
        public StudentService(IRepository<Student> _studentContext,IRepository<Standard> _stdContext)
        {
            this._studentContext = _studentContext;
            this._stdContext = _stdContext;
        }
        public void DeleteStudent(int studentId)
        {
            _studentContext.Delete(studentId);
            _studentContext.Commit();
        }
        public IEnumerable<ClassStudentViewModel> GetClassStudentViewModels()
        {
            var returnModel = GetStandards().Select(x => new ClassStudentViewModel 
            { 
                classId=x.Id,
                students=getStudents(x.Id)
            });
            return returnModel;
        }
        private IEnumerable<Standard> GetStandards()
        {
            var standards = _stdContext.Collection();
            return standards;
        }
        

        private IEnumerable<Student> getStudents(int classId)
        {
            var studentlist = _studentContext.Collection().Where(x => x.ClassId == classId);
            return studentlist;
        }

        public void InsertStudent(Student student)
        {
            _studentContext.Insert(student);
            _studentContext.Commit();

        }

        public void UpdateStudent(Student student)
        {
            _studentContext.Edit(student);
            _studentContext.Commit();
        }

        
    }
}