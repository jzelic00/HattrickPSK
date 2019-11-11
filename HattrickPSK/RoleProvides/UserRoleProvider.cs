using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using HattrickPSK.DataAcces;
using HattrickPSK.Models;

namespace HattrickPSK.RoleProvides
{
    public class UserRoleProvider : RoleProvider
    {
        DAL dataAccess = new DAL();
        User currentUser = new User();
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
                var userRoles = (from user in dataAccess.db.User
                                 join roleMapping in dataAccess.db.UserRole
                                 on user.UserID equals roleMapping.UserID
                                 join role in dataAccess.db.Role
                                 on roleMapping.RoleID equals role.RoleID
                                 where user.Username == username
                                 select role.RoleName).ToArray();
                return userRoles;                      
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            currentUser = dataAccess.fingUserByUsername(username);
            return currentUser.UserRole.Where(p => p.Role.RoleName == roleName).Any();
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