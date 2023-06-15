﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Factory;
namespace LAB_RAMEN.Handler
{
    public class RegisterHandler
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();
       public static bool insertUser(int id, int roleid, string username, string email,string gender,string password)
        {
            try
            {
                User u = FactoryData.createUser(id, roleid, username, email, gender, password);
                db.Users.Add(u);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}