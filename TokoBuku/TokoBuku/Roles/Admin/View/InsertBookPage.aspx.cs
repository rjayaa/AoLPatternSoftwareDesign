using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBuku.Roles.Admin.View
{
    public partial class InsertBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            string id = Controller.GenerateID.generateID("BOK", "Books", "BookID");
            Controller.BookController.insertbook(id, txtTitle.Text, txtAuthor.Text, txtPublisher.Text, Convert.ToInt32(txtPublicationYear.Text), Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtStock.Text));
        }
    }
}