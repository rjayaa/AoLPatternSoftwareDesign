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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void clearInsert()
        {
            txtTitleBook.Text = "";
            txtAuthorBook.Text = "";
            txtPublisherBook.Text = "";
            txtPublicationYear.Text = "";
            txtPriceBook.Text = "";
            txtStockBook.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Controller.GenerateID.generateID("BOK", "Books", "BookID");
            var result = BookController.InsertBook(id, txtTitleBook.Text,
                txtAuthorBook.Text, txtPublisherBook.Text, txtPublicationYear.Text,
                txtPriceBook.Text, txtStockBook.Text);
            txtLblError.Text = result.message;
            txtLblError.ForeColor = result.color;
            if(txtLblError.Text.Equals("Insert Success!!")) clearInsert();

        }
    }
}