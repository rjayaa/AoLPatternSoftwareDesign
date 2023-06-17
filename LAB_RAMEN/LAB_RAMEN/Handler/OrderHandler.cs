using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
using LAB_RAMEN.Factory;
namespace LAB_RAMEN.Handler
{
    public class OrderHandler
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        public static List<Detail> GetDetailData(int headerid)
        {
            return OrderRepository.GetDetailDataByHeaderID(headerid);
        }
        
        public static bool insertHeader(int id , int customerid)
        {
            try
            {
                Header hd = FactoryData.createHeader(id, customerid);
                db.Headers.Add(hd);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool insertDetail(int hid,int rid, int q)
        {
            try
            {
                Detail d = FactoryData.createDetail(hid,rid,q);
                db.Details.Add(d);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool RemoveLastHeaderData()
        {
            try
            {
                var lastHeader = OrderRepository.GetLastHeader();
                if (lastHeader != null)
                {
                    db.Headers.Remove(lastHeader);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}