using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;

using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Handler
{
    public class LoginHandler
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();

        public static User loginHandler(string username, string password)
        {
            return db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}