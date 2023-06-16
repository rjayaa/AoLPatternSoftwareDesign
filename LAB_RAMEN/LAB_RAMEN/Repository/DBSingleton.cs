using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class DBSingleton
    {
        static DatabaseRamenEntities db = null;

        public static DatabaseRamenEntities GetInstance()
        {
            if(db == null)
            {

                db = new DatabaseRamenEntities();
            }
            return db;
        }
    }
}