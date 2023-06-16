using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class CustomerRepository
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();

        public static List<Raman> GetRamen()
        {
            return db.Ramen.ToList();
        }

        public static Detail FindRamen(int headerId, int ramenId)
        {
            Detail d = db.Details.Where(x => x.RamenID == ramenId && x.HeaderID == headerId).FirstOrDefault();
            return d;
        }
        public static string GetRamenNameById(int ramenID)
        {
                Raman ramen = db.Ramen.FirstOrDefault(r => r.id == ramenID);
                if (ramen != null)
                {
                    return ramen.Name;
                }
            
            return string.Empty;
        }

      
    
    }
}