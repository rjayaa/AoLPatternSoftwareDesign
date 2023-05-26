using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
using TokoBuku.Repository;

namespace TokoBuku.Roles.Admin.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        private List<SelectedBook> selectedBooks = new List<SelectedBook>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCustomerIDs.Text = Request["ID"];
                BindGridViewBook();
                RegisterCustomScript();
            }
            else
            {
                // Retrieve the selected books from the session variable
                if (Session["SelectedBooks"] != null)
                {
                    selectedBooks = (List<SelectedBook>)Session["SelectedBooks"];
                }
            }
        }

        protected void RegisterCustomScript()
        {
            // Tambahkan kode JavaScript secara dinamis
            string script = @"
        function validNumeric() {
            var charcode = (event.which) ? event.which : event.keyCode;
            if (charcode >= 48 && charcode <= 57) {
                return true;
            } else {
                return false;
            }
        }
    ";

            ScriptManager.RegisterStartupScript(this, GetType(), "CustomScript", script, true);
        }

        private void BindGridViewBook()
        {
            var bk = Repository.Repository.getBook();
            gridViewBook.DataSource = bk;
            gridViewBook.DataBind();
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (gridViewBook.SelectedRow != null)
            {
                GridViewRow selectedRow = gridViewBook.SelectedRow;
                string stock = selectedRow.Cells[6].Text;
                int stockGridView = Convert.ToInt32(stock);
                int inputStock;

                if (int.TryParse(txtQuantity.Text, out inputStock))
                {
                    if (inputStock <= stockGridView)
                    {
                        // Get the selected book details
                        string bookID = selectedRow.Cells[0].Text;
                        string title = selectedRow.Cells[1].Text;
                        string author = selectedRow.Cells[2].Text;
                        string publisher = selectedRow.Cells[3].Text;
                        string publicationYear = selectedRow.Cells[4].Text;
                        string price = selectedRow.Cells[5].Text;
                        string selectedStock = selectedRow.Cells[6].Text;

                        // Create a new SelectedBook object
                        SelectedBook selectedBook = new SelectedBook
                        {
                            BookID = bookID,
                            Title = title,
                            Author = author,
                            Publisher = publisher,
                            PublicationYear = publicationYear,
                            Price = price,
                            Stock = inputStock.ToString(),
                        };

                        // Add the selected book to the list
                        selectedBooks.Add(selectedBook);

                        // Store the updated list in the session variable
                        Session["SelectedBooks"] = selectedBooks;

                        // Bind the selected books to the GridView
                        gridViewSelectedBooks.DataSource = selectedBooks;
                        gridViewSelectedBooks.DataBind();

                        //gridViewBook.SelectedIndex = -1; // Deselect the row

                        btnClear.Visible = true;
                        btnSave.Visible = true;
                        txtlblerror.Text = ""; // Clear error message
                        txtQuantity.Text = ""; // Clear input textbox
                        string script = "$('#ValidationModal').modal('show')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                        txtPopup.Text = "Success!";
                        txtValidation.Text = "Book Added!!";
                    }
                    else if (inputStock > stockGridView)
                    {
                        string script = "$('#ValidationModal').modal('show')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                        txtPopup.Text = "Failed!!!";
                        txtValidation.Text = "Input value exceeds the available stock.";
                    }
                }
                else
                {
                    string script = "$('#ValidationModal').modal('show')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                    txtPopup.Text = "Failed!!!";
                    txtValidation.Text = "Number Cannot Be Empty";
                }
            }
            else
            {
                txtlblerror.Text = "Please select a book.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            selectedBooks.Clear();
            Session["SelectedBooks"] = null;
            gridViewSelectedBooks.DataSource = null;
            gridViewSelectedBooks.DataBind();
            btnClear.Visible = false;
            btnSave.Visible = false;

        }


        protected void gridViewBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                gridViewBook.SelectedIndex = rowIndex;
                txtQuantity.Text = "";
                string script = "$('#mymodal').modal('show')";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                
            }
        }

        internal class SelectedBook
        {
            public string BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public string PublicationYear { get; set; }
            public string Price { get; set; }
            public string Stock { get; set; }

            public SelectedBook Clone()
            {
                return (SelectedBook)MemberwiseClone();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
