using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
using TokoBuku.Repository;
using TokoBuku.Controller;
namespace TokoBuku.Roles.Admin.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string customerID = Request.QueryString["customerid"];
                txtTransactionID.Text = Request.QueryString["transactionid"];
                txtCustomerIDs.Text = Request["ID"];
                BindGridViewBook();
                RegisterCustomScript();
                // Initialize the selectedBooks list if it's null
                
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


        protected void btnClear_Click(object sender, EventArgs e)
        {
            //selectedBooks.Clear();
            //Session["SelectedBooks"] = null;
            //gridViewSelectedBooks.DataSource = null;
            //gridViewSelectedBooks.DataBind();
            btnClear.Visible = false;
            btnSave.Visible = false;

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

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

                        // Create a new TransactionDetail object
                        string transactionDetailID = Controller.GenerateID.generateID("TDD", "TransactionDetail", "TransactionDetailID");
                        var res = Controller.TransactionDetailController.insertTransactionDetail(transactionDetailID, txtTransactionID.Text, bookID, inputStock);

                        if (res == true)
                        {
                            // Show success message
                            string script = "$('#ValidationModal').modal('show')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                            txtPopup.Text = "Success!";
                            txtValidation.Text = "Book Added!!";
                            btnClear.Visible = true;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            // Show error message
                            string script = "$('#ValidationModal').modal('show')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                            txtPopup.Text = "Failed!!!";
                            txtValidation.Text = "Failed to add book.";
                            btnClear.Visible = false;
                            btnSave.Visible = false;
                        }

                        // Clear input textbox
                        txtQuantity.Text = "";
                    }
                    else if (inputStock > stockGridView)
                    {
                        // Show error message
                        string script = "$('#ValidationModal').modal('show')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
                        txtPopup.Text = "Failed!!!";
                        txtValidation.Text = "Input value exceeds the available stock.";
                    }
                }
                else
                {
                    // Show error message
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


    }
}
