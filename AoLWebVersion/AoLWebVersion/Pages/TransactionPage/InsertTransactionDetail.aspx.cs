using AoLWebVersion.Model;
using AoLWebVersion.Repository_and_DatabaseSingleton.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoLWebVersion.Pages
{
    public partial class InsertTransactionDetail : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        public Customer cust = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Book> book = db.Books.ToList();
                
                BookGridView.DataSource = book;
                BookGridView.DataBind();

                CustomerRepository repo = new CustomerRepository();
                string id = Request.QueryString["id"];

                cust = repo.FindById(id);
                txtCustID.Text = cust.CustomerID;
                txtCustName.Text = cust.Name;

            }

        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            List<Book> selectedBooks = new List<Book>();
            foreach (GridViewRow row in BookGridView.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkselect");
                if (chkselect.Checked)
                {
                    Book book = new Book();
                    book.BookID = row.Cells[1].Text;
                    book.Title = row.Cells[2].Text;
                    book.Author = row.Cells[3].Text;
                    book.Publisher = row.Cells[4].Text;
                    book.PublicationYear = Convert.ToInt32(row.Cells[5].Text);
                    book.Price = Convert.ToInt32(row.Cells[6].Text);
                    selectedBooks.Add(book);
                    BookViewSection.DataSource = selectedBooks;
                    BookViewSection.DataBind();
                }
            }
           
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            BookViewSection.DataSource = null;
            BookViewSection.DataBind();

            foreach (GridViewRow row in BookGridView.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkselect");

                if (chkselect.Checked)
                {
                    chkselect.Checked = false;
                }
            }
        }
    }
}