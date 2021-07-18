﻿using MyAttendance.Models.Components;
using MyAttendance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttendance.Repositories
{
   public interface IStudentService
    {

        IEnumerable<ClassStudentViewModel> GetClassStudentViewModels();
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);

    }
}
