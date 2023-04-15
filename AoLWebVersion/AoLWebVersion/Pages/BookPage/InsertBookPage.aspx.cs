using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoLWebVersion.Pages
{
    public partial class BookPage : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPublicationYear.TextChanged += new EventHandler(txtPublicationYear_TextChanged1);
        }

        protected string generateID(string prefix)
        {
            string newId = "";
            string lastId = (from x in db.Books select x.BookID).ToList().LastOrDefault();

            if (lastId == null)
            {
                newId = prefix + "001";
            }
            else if (lastId.Length != 6 || !lastId.StartsWith(prefix))
            {
                throw new Exception("Invalid customer ID format");
            }
            else
            {
                int idNumber = Convert.ToInt32(lastId.Substring(3));
                idNumber++;
                newId = String.Format("{0}{1:000}", prefix, idNumber);
            }

            return newId;
        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {
           
                Book bk = Factory.Factory.createBook(generateID("BOK"), txtTitleBook.Text, txtAuthorBook.Text, txtPublisherBook.Text, Convert.ToInt32(txtPublicationYear.Text), Convert.ToInt32(txtPriceBook.Text), Convert.ToInt32(txtStockBook.Text));
                db.Books.Add(bk);
                db.SaveChanges();
           
        }

        protected void txtPublicationYear_TextChanged1(object sender, EventArgs e)
        {
            if (txtPublicationYear.Text.Length == 4)
            {
                // cek apakah input hanya terdiri dari angka
                int year;
                bool isNumeric = int.TryParse(txtPublicationYear.Text, out year);
                if (isNumeric)
                {
                    // input valid, bisa dilakukan pengolahan lebih lanjut
                }
                else
                {
                    // input tidak valid, tampilkan pesan error
                    txtPublicationYear.Text = "";
                    txtLblError.Text = "Input harus berupa angka";
                }
            }
            else
            {
                // panjang input belum mencapai 4 digit, kosongkan pesan error
                txtLblError.Text = "";
            }
        }
    }
}