using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class DatabaseSingleton
    {
        // Singleton
        // Kalo kita punya class maka kita akan punya objek
        // otomatis setiap objek akan memiliki atribut yang berbeda

        // kalau pake singleton, kita cuman mau ada satu objek aja yang dipake


        // buat constructor
        static DatabaseGuitarEntities db = null;
        private DatabaseSingleton()
        {

        }

        public static DatabaseGuitarEntities GetInstance()
        {
            // validasi untuk ngecek database null atau engga
            if (db == null)
            {
                db = new DatabaseGuitarEntities();
            }
            return db;
        }

    }
}