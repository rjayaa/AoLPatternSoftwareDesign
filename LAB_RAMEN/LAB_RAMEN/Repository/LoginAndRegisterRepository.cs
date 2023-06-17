using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Factory;
namespace LAB_RAMEN.Repository
{
    public class LoginAndRegisterRepository
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        public static User LoginRepository(string username, string password)
        {
            return db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public static bool RegisterRepository(int id, int roleid, string username, string email, string gender, string password)
        {
                User u = FactoryData.createUser(id, roleid, username, email, gender, password);
                db.Users.Add(u);
                db.SaveChanges();
                return true; 
        }
    }
}