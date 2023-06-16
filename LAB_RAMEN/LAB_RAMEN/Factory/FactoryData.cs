using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Factory
{
    
    public class FactoryData
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();

        public static User createUser(int id, int roleid, string username, string email, string gender , string password)
        {
            User u = new User();
            u.id = id;
            u.RoleID = roleid;
            u.Username = username;
            u.Email = email;
            u.Gender = gender;
            u.Password = password;

            return u;
        }


        public static Header AddHeaderFromUser(int customerId)
        {
            Header h = new Header();
            h.id = GenerateIDRepository.GenerateID("Header");
            h.CustomerID = customerId;
            h.StaffID = 0;
            h.Date = DateTime.Now;
            return h;
        }

        public static Detail AddDetail(int headerId, int ramenId, int quantity)
        {
            Detail d = new Detail();
            d.HeaderID = headerId;
            d.RamenID = ramenId;
            d.Quantity = quantity;
            return d;
        }
    }
}