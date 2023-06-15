using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Factory
{
    
    public class FactoryData
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();

        public static User createUser(int id, int roleid, string username, string email, string gender , string password)
        {
            User u = new User();
            u.id = id;
            u.RoleID = roleid;
            u.Username = username;
            u.Email = email;
            u.Gender = gender;
            u.Password = password;

            return u;
        }
    }
}