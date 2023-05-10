using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Controller;

namespace TokoBuku.View
{
    public partial class InsertBook : System.Web.UI.Page
    {
        //string id = Controller.generateID("BOK", "Books", "BookID");
        string id = Controller.Controller.generateID("BOK", "Books", "BookID");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int publicationYear;
            int price;
            int stock;
            if (!int.TryParse(txtPublicationYear.Text, out publicationYear) || !int.TryParse(txtPriceBook.Text, out price) || !int.TryParse(txtStockBook.Text, out stock))
            {
                txtLblError.Text = "Invalid input for publication year, price, or stock";
            }
            else
            {
                txtLblError.Text = BookController.InsertBook(id, txtTitleBook.Text, txtAuthorBook.Text, txtPublisherBook.Text, publicationYear, price, stock);
            }

        }
    }
}