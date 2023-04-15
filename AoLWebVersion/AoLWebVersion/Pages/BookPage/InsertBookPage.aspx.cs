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
            txtLblError.ForeColor = System.Drawing.Color.Red;
            if (txtTitleBook.Text == "")
            {
                txtLblError.Text = "Please enter the title of the book";
            }
            else if (txtAuthorBook.Text == "")
            {
                txtLblError.Text = "Please enter the author of the book";
            }
            else if (txtPublisherBook.Text == "")
            {
                txtLblError.Text = "Please enter the publisher of the book";
            }
            else if (txtPublicationYear.Text == "")
            {
                txtLblError.Text = "Please enter the publication year of the book";
            }
            else if (txtPriceBook.Text == "" || txtPriceBook.Text == "0")
            {
                txtLblError.Text = "Please enter the price of the book [cannot be 0]";
            }
            else if (txtStockBook.Text == "" || txtStockBook.Text == "0")
            {
                txtLblError.Text = "Please enter the stock of the book [cannot be 0]";
            }else
            {
                Book bk = Factory.Factory.createBook(generateID("BOK"), txtTitleBook.Text, txtAuthorBook.Text, txtPublisherBook.Text, Convert.ToInt32(txtPublicationYear.Text), Convert.ToInt32(txtPriceBook.Text), Convert.ToInt32(txtStockBook.Text));
                db.Books.Add(bk);
                db.SaveChanges();
                txtLblError.ForeColor = System.Drawing.Color.Green;
                txtLblError.Text = "Insert Success!!";
            }
        }

    }
}