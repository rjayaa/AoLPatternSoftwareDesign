using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.Repository
{
    public class OrderRepository
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        public static List<Header> GetQueueOrder()
        {
            List<Header> rm = db.Headers.Where(h => h.StaffID == 0).ToList(); ;
            return rm;
        }

        public static List<Header> GetUserHistoryTransaction(int userid)
        {
            List<Header> headers = db.Headers.Where(h => h.CustomerID == userid && h.StaffID > 0).ToList();
            return headers;
        }
        public static void HandleOrderByStaff(int headerid, int staffid)
        {
            Header headerToUpdate = db.Headers.FirstOrDefault(h => h.id == headerid);
            headerToUpdate.StaffID = staffid;
            db.SaveChanges();
        }

        public static Detail FindRamen(int headerId, int ramenId)
        {
            Detail d = db.Details.Where(x => x.RamenID == ramenId && x.HeaderID == headerId).FirstOrDefault();
            return d;
        }
        public static List<Header> GetHandledData()
        {
            return db.Headers.Where(x => x.StaffID > 0).ToList();
        }

        public static List<Detail> GetDetailDataByHeaderID(int headerid)
        {
            List<Detail> dt = db.Details.Where(l => l.HeaderID == headerid).ToList();
            return dt;
        }

        public static Header GetLastHeader()
        {
            return db.Headers.OrderByDescending(h => h.id).FirstOrDefault();
        }
    }
}