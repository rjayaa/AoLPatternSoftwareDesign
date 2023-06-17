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
            List<Header> h = db.Headers.Where(p => p.CustomerID == userid).ToList();
            return h;
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

        public static void createTransaction(int headerid, List<Detail> orderdetails)
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Header header = db.Headers.Find(headerid);
                    db.Headers.Attach(header);
                    db.Entry(header).State = EntityState.Modified;
                    db.SaveChanges();

                    
                    foreach (Detail detail in orderdetails)
                    {
                        detail.HeaderID = headerid;
                        db.Details.Add(detail);
                    }
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
           
        }
    }
}