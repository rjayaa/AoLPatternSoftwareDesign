using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Repository
{
    public class UserRepository
    {
        static TokoBukuDatabaseEntities2 db = new TokoBukuDatabaseEntities2();

        public static User getUser(String Username, String Password)
        {
            return (from x in db.Users where x.username == Username && x.password == Password select x).FirstOrDefault();
        }
    }
}