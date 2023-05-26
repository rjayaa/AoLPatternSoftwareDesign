using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBukuKita.Repository;
using TokoBukuKita.Model;
using System.Web.Services;

namespace TokoBukuKita.View.Admin
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                bindBookList();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btnView = (Button)sender;
            GridViewRow row = (GridViewRow)btnView.NamingContainer;
            string customerID = row.Cells[0].Text;
            string customerName = row.Cells[1].Text;
            string customerAddress = row.Cells[2].Text;
            string customerPhone = row.Cells[3].Text;
            string customerEmail = row.Cells[4].Text;

            txtCustomerID.Text = customerID;
            txtName.Text = customerName;

            //string script = @"<script type='text/javascript'>
            //                    $(document).ready(function () {
            //                        $('#mymodal').modal('show');
            //                    });
            //                </script>";
            string script = @"<script type='text/javascript'>
                        $(document).ready(function () {
                            $('#mymodal').modal({
                                backdrop: 'static',
                                keyboard: false
                            });
                        });
                    </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "ModalScript", script);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string transactionID = Controller.GenerateID.generateID("TRD", "Transactions", "TransactionID");
                string customerID = txtCustomerID.Text;
                string customerName = txtName.Text;
                DateTime orderDate = DateTime.Now;

                Transaction transaction = Factory.Factory.createTransaction(transactionID, customerID, orderDate);
                //Repository.saveTransaction(transaction);

                // Clear form fields
                txtCustomerID.Text = "";
                txtName.Text = "";

                // Refresh grid view
                BindGridView();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred during saving transaction: " + ex.Message);
            }
        }

        private void BindGridView()
        {
            var customers = Repository.Repository.getCustomer();
            gridViewCustomer.DataSource = customers;
            gridViewCustomer.DataBind();
        }

        private void bindBookList()
        {
            // Fetch data dari repository
            List<Book> books = Repository.Repository.GetBook();

            // Bind data ke DropDownList
            dropDownList.DataSource = books;
            dropDownList.DataTextField = "Title";
            dropDownList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string id = Controller.GenerateID.generateID("TRD", "Tr", "CustomerID");
        }
    }
}
