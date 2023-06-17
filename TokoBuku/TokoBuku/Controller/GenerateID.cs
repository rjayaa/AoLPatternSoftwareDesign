using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    
    public class GenerateID
    {
        static TokoBukuEntities db = new TokoBukuEntities();

        public static String generateID(string prefix, string table, string attribute)
        {
            string newId = "";
            var query = string.Format("SELECT TOP 1 {0} FROM {1} ORDER BY {0} DESC", attribute, table);
            var lastId = db.Database.SqlQuery<string>(query).FirstOrDefault();

            if (lastId == null)
            {
                newId = prefix + "001";
            }
            else if (lastId.Length != 6 || !lastId.StartsWith(prefix))
            {
                throw new Exception("Invalid ID format");
            }
            else
            {
                int idNumber = Convert.ToInt32(lastId.Substring(3));
                idNumber++;
                newId = String.Format("{0}{1:000}", prefix, idNumber);
            }

            return newId;
        }


    }
}