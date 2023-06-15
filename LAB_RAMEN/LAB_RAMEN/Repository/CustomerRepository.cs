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
    }
}