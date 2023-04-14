using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AoLWebVersion.Model;

namespace AoLWebVersion.Repository
{
    public class DataSingleton
    {
        static tokoBukuEntities db = null;
        private DataSingleton()
        {

        }
        public static tokoBukuEntities GetInstance()
        {
            if (db == null) db = new tokoBukuEntities();

            return db;
        }
    }
}