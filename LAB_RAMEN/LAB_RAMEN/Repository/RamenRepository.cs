using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class RamenRepository
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();

        public static List<Raman> GetRamen()
        {
            List<Raman> r = db.Ramen.ToList();
            return r;
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

        public static List<string> GetMeatData()
        {
            List<string> m = db.Meats.Select(x => x.Name).ToList();
            return m;

        }
        public static List<string> GetBrothData()
        {
            List<string> m = db.Meats.Select(x => x.Name).ToList();
            return m;

        }

        public static int GeatIdByMeatName(string meatname)
        {
            Meat meat = db.Meats.FirstOrDefault(m => m.Name == meatname);
             return meat.id;
                    
        }
        public static string GeatMeatNameById(int meatid)
        {
            Meat meat = db.Meats.FirstOrDefault(m => m.id == meatid);
            return meat.Name;

        }
    }
}