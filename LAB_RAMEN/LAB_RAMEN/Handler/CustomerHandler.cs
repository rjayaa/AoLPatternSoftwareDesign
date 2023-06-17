using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Handler
{
    public class CustomerHandler
    {
        public static User UpdateHandler(int userid)
        {
            User user = DBSingleton.GetInstance().Users.Find(userid);
            return user;
        }
    }
}