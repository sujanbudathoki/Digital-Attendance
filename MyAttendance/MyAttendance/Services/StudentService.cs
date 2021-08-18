using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using MyAttendance.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyAttendance.Services
{
    public class StudentService : IStudentService
    {
        IRepository<Student> _studentContext;
        IRepository<Standard> _stdContext;
        public StudentService(IRepository<Student> _studentContext, IRepository<Standard> _stdContext)
        {
            this._studentContext = _studentContext;
            this._stdContext = _stdContext;
        }
        public void DeleteStudent(int studentId)
        {
            _studentContext.Delete(studentId);
            _studentContext.Commit();
        }
        public List<ClassStudentViewModel> GetClassStudentViewModels()
        {
            var returnModel = GetStandards()
            .Select(x => new ClassStudentViewModel
            {
                classId = x.Id,
                students = getStudents(x.Id)
            }).ToList();

            return returnModel;
        }
        public IEnumerable<Standard> GetStandards()
        {
            var standards = _stdContext.Collection();
            return standards;
        }


        public IList<Student> getStudents(int classId)
        {
            var studentlist = _studentContext.Collection()
                                             .Where(x => x.ClassId == classId)
                                             .ToList();

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

        public string getClassName(int classId)
        {
            string name = _stdContext.Collection()
                                     .Where(x => x.Id == classId)
                                     .FirstOrDefault()
                                     .StandardName;
            return name;
        }



    }
}