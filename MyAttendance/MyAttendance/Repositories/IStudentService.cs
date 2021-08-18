using MyAttendance.Models.Components;
using MyAttendance.ViewModels;
using System.Collections.Generic;

namespace MyAttendance.Repositories
{
    public interface IStudentService
    {

        List<ClassStudentViewModel> GetClassStudentViewModels();
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        string getClassName(int classId);
        IEnumerable<Standard> GetStandards();


    }
}

