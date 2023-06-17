using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;

namespace LAB_RAMEN.Repository
{
    public class AdminRepository
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        public static List<User> GetAllCustomers()
        {
            return db.Users.Where(u => u.RoleID == 3).ToList();
        }
        public static List<User> GetAllStaff()
        {
            return db.Users.Where(u => u.RoleID == 2).ToList();
        }
        public static List<Header> GetAllTransaction()
        {
            return db.Headers.ToList();
        }
    }
}