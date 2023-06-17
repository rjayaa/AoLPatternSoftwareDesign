using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class DBSingleton
    {
        static DatabaseRamenEntities1 db = null;

        public static DatabaseRamenEntities1 GetInstance()
        {
            if(db == null)
            {

                db = new DatabaseRamenEntities1();
            }
            return db;
        }
    }
}