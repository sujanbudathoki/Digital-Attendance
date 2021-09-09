using MyAttendance.DataAccess;
using MyAttendance.Models;
using MyAttendance.Models.User;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MyAttendance.App_Start
{
    public class RoleProviderConfig : RoleProvider
    {
           
            IRepository<UserModel> _userContext;
            IRepository<UserType> _userTypeContext;

      public RoleProviderConfig():this(new SQLRepository<UserModel>()
                                      ,new SQLRepository<UserType>())
      {

      }

    
        public RoleProviderConfig(IRepository<UserModel> _userContext,
                                  IRepository<UserType> _userTypeContext)
        {
            this._userContext = _userContext;
            this._userTypeContext = _userTypeContext;
              
        }


        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var users = (from u in _userContext.Collection()
                         join r in _userTypeContext.Collection()
                         on u.UserTypeId equals r.Id
                         where u.Email == username
                         select r.Type
                         ).ToArray();
            return users;

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}