using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;

namespace TokoBuku.Roles.Admin.View
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPaymentID.Text = Controller.GenerateID.generateID("PAY", "Payments", "PaymentID");
                fetchDropDownTransactionID();
                
                
            }
        }

        protected void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                lblMessage.Text = "Invalid amount.";
                lblMessage.CssClass = "text-danger";
                txtAmount.Text = string.Empty;
            }
            else
            {
                // Hapus spasi pada nilai input sebelum parsing
                string amountText = txtAmount.Text.Trim();

                int amount;
                if (int.TryParse(amountText, out amount))
                {
                    DateTime paymentDate = DateTime.Now;
                    string transactionId = ddlTransactionID.SelectedValue;
                    string paymentMethod = ddlPaymentMethod.SelectedValue;

                    bool success = Controller.PaymentController.insertPayment(txtPaymentID.Text, transactionId, amount, paymentDate, paymentMethod);

                    if (success)
                    {
                        // Tindakan jika penyisipan data berhasil
                        lblMessage.Text = "Payment has been successfully added.";
                        lblMessage.CssClass = "text-success";

                        // Reset nilai-nilai textbox dan dropdown ke nilai default
                        txtPaymentID.Text = Controller.GenerateID.generateID("PAY", "Payments", "PaymentID");
                        txtAmount.Text = string.Empty;
                        ddlTransactionID.SelectedIndex = 0;
                        ddlPaymentMethod.SelectedIndex = 0;
                    }
                    else
                    {
                        // Tindakan jika penyisipan data gagal
                        lblMessage.Text = "Failed to add payment.";
                        lblMessage.CssClass = "text-danger";
                    }
                }
                else
                {
                    // Tindakan jika parsing jumlah gagal
                    lblMessage.Text = "Invalid amount.";
                    lblMessage.CssClass = "text-danger";
                    txtAmount.Text = string.Empty;
                }
            }
        }



        public void CalculateAmount(string transactionID)
        {
            using (var db = new TokoBukuEntities())
            {
                int? totalAmount = (
                    from td in db.TransactionDetails
                    join b in db.Books on td.BookID equals b.BookID
                    where td.TransactionID == transactionID
                    select (int?)(td.Quantity * b.Price)
                ).Sum();

                if (totalAmount.HasValue)
                {
                    txtAmount.Text = totalAmount.Value.ToString("D0"); // Menggunakan "N0" untuk format angka tanpa desimal
                }
                else
                {
                    txtAmount.Text = "0";
                }
            }
        }

        private void fetchDropDownTransactionID()
        {
            List<Transaction> transactions = Repository.Repository.getTransactions();
            List<string> transactionIDs = transactions.Select(t => t.TransactionID).ToList();

            ddlTransactionID.DataSource = transactionIDs;
            ddlTransactionID.DataBind();

            // Add an optional default item
            ddlTransactionID.Items.Insert(0, new ListItem("Select Transaction ID", ""));
        }

     

        protected void ddlTransactionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount(ddlTransactionID.SelectedValue);
        }


        

        protected void btnRefreshAmount_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ddlTransactionID.Text;
        }
    }
}
