using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoLWebVersion.Model;
namespace AoLWebVersion.Pages
{
    public partial class InsertTransactionPage : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                List<Customer> cust = db.Customers.ToList();
                CustGridView.DataSource = cust;
                CustGridView.DataBind();
                List<Book> book = db.Books.ToList();
                BookGridView.DataSource = book;
                BookGridView.DataBind();
            }
        }



        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string temp = txtSearch.Text.ToLower();

            var cust = (from c in db.Customers
                        where c.Name.ToLower().Contains(temp)
                        select c);

            CustGridView.DataSource = cust.ToList();
            CustGridView.DataBind();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            clearView();
        }

        protected void clearView()
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
            btnSave.Visible = false;
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
                    btnSave.Visible = true;
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            //DateTime now = DateTime.Now;
            //Transaction td = Factory.Factory.createTransaction(generateID("TRD"), txtCustID.Text, now);
            //db.Transactions.Add(td);
            //db.SaveChanges();
            txtVerification.ForeColor = System.Drawing.Color.Green;
            txtVerification.Text = "Save Data Succed!";
        }



    }
}