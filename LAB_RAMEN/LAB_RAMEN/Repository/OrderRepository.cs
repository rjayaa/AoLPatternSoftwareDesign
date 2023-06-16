using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class OrderRepository
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();
        public static List<Header> GetQueueOrder()
        {
            List<Header> rm = db.Headers.Where(h => h.StaffID == 0).ToList(); ;
            return rm;
        }


        public static void HandleOrderByStaff(int headerid, int staffid)
        {
            Header headerToUpdate = db.Headers.FirstOrDefault(h => h.id == headerid);
            headerToUpdate.StaffID = staffid;
            db.SaveChanges();
        }

        public static List<Header> GetHandledData()
        {
            return db.Headers.Where(x => x.StaffID > 0).ToList();
        }
    }
}