using PersonelMVCUI.Models.Entity;
using System;
using System.Linq;
using System.Web.Security;

namespace PersonelMVCUI.Security
{
    // web.config dosyasına "roleManager" eklendi.
    public class PersonelRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        //DB'de bu isim varsa, onun rolünü döndürür.
        public override string[] GetRolesForUser(string username)
        {
            PersonelEntities db = new PersonelEntities();
            var kullanici = db.Kullanici.FirstOrDefault(m => m.Ad == username);

            return new string[] { kullanici.Role };
        }

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