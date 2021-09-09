using MyAttendance.Models.User;
using MyAttendance.Models.User.ViewModel;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MyAttendance.Controllers
{
    public class ManageRolesController : Controller
    {
        IRepository<UserModel> _userContext;
        IRepository<UserType> _userTypeContext;

        public ManageRolesController(IRepository<UserModel> _userContext,IRepository<UserType> _userType)
        {
            this._userContext = _userContext;
            this._userTypeContext = _userType;
        }
        // GET: ManageRoles
        public ActionResult Index()
        {
            var HODmodel =  (from u in _userContext.Collection()
                             join ut in _userTypeContext.Collection()
                             on u.UserTypeId equals ut.Id
                             where u.UserTypeId == 1
                             select new UserIndexViewModel()
                             {
                              Id = u.Id,
                              Email = u.Email,
                              Name = u.Name,
                              RoleType = ut.Type
                             });

            var teacherModel = (from u in _userContext.Collection()
                                join ut in _userTypeContext.Collection()
                                on u.UserTypeId equals ut.Id
                                where u.UserTypeId == 2
                                select new UserIndexViewModel()
                                {
                                    Id = u.Id,
                                    Email = u.Email,
                                    Name = u.Name,
                                    RoleType = ut.Type
                                });

            var studentModel = (from u in _userContext.Collection()
                                join ut in _userTypeContext.Collection()
                                on u.UserTypeId equals ut.Id
                                where u.UserTypeId == 3
                                select new UserIndexViewModel()
                                {
                                    Id = u.Id,
                                    Email = u.Email,
                                    Name = u.Name,
                                    RoleType = ut.Type
                                });
            var typeList = new UserTypeList()
            {
                Students = studentModel.ToList(),
                HOD = HODmodel.ToList(),
                Teacher = teacherModel.ToList()
            };

            return View(typeList);
        }

        public ActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                bool repeatedEmail = _userContext.Collection().Any(x => x.Email == model.Email);
                if (repeatedEmail)
                {
                    ViewBag.Error = "Email is already taken";
                    return View(model);
                }
                else
                {
                    var teacherModel = new UserModel()
                    {
                        Name = model.Email,
                        Password = model.Password,
                        Address = model.Address,
                        Email = model.Address,
                        Gender = model.Gender,
                        UserTypeId = 2,
                        ConfirmPassword=model.ConfirmPassword
                    };
                    _userContext.Insert(teacherModel);
                    _userContext.Commit();
                    return RedirectToAction("Index");
                }
            }
            
        }

       
    }
}