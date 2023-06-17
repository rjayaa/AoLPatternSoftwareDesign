using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class GenerateIDRepository
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        public static int GenerateID(string table)
        {
            int newID = 1;
            switch (table)
            {
                case "User":
                    if (db.Users.Any())
                        newID = db.Users.Max(item => item.id) + 1;
                    break;
                case "Ramen":
                    if (db.Ramen.Any())
                        newID = db.Ramen.Max(item => item.id) + 1;
                    break;
                case "Header":
                    if (db.Headers.Any())
                        newID = db.Headers.Max(item => item.id) + 1;
                    break;
                default:
                    throw new ArgumentException("Invalid table name.");
            }
            return newID;
        }
    }
}