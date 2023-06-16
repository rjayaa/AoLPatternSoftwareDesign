using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Factory;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Handler
{
    public class RamenHandler
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();
        public static bool insertRamen(int id, string meatname, string name, string broth,string price)
        {

            int meatid = RamenRepository.GeatIdByMeatName(meatname);
            try
            {
                Raman r = FactoryData.createRamen(id, meatid, name, broth, price);
                db.Ramen.Add(r);
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