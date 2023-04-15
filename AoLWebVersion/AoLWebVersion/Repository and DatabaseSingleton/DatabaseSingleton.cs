using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoLWebVersion.Repository_and_DatabaseSingleton
{
    public class DatabaseSingleton
    {
        private static tokoBukuEntitiess db = null;

        private DatabaseSingleton()
        {

        }

        public static tokoBukuEntitiess GetInstance()
        {
            if (db == null) db = new tokoBukuEntitiess();

            return db;
        }
    }
}