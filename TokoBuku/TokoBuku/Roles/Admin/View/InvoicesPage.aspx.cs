using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
namespace TokoBuku.Roles.Admin.View
{
    public partial class InvoicesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtInvoiceID.Text = Controller.GenerateID.generateID("IVC", "Invoices", "InvoiceID");
                fetchDropDownTransactionID();
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

            // Calculate amount based on the selected value
            CalculateAmount(ddlTransactionID.SelectedValue);
        }

        protected void ddlTransactionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount(ddlTransactionID.SelectedValue);
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

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                lblMessage.Text = "Invalid amount.";
                lblMessage.CssClass = "text-danger";
                txtAmount.Text = string.Empty;
            }
            else
            {
                string transactionId = ddlTransactionID.SelectedValue;
                int amount = 0;
                if (int.TryParse(txtAmount.Text.Trim(), out amount))
                {
                    DateTime issuedDate = DateTime.Now;

                    // Tambahkan kode untuk memanggil fungsi insertInvoices dari controller
                    bool success = Controller.InvoicesController.insertInvoices(txtInvoiceID.Text, transactionId, amount, issuedDate);

                    if (success)
                    {
                        // Tindakan jika penyisipan data berhasil
                        lblMessage.Text = "Invoice has been successfully added.";
                        lblMessage.CssClass = "text-success";

                        // Reset nilai-nilai textbox dan dropdown ke nilai default
                        txtInvoiceID.Text = Controller.GenerateID.generateID("IVC", "Invoices", "InvoiceID");
                        txtAmount.Text = string.Empty;
                        ddlTransactionID.SelectedIndex = 0;
                    }
                    else
                    {
                        // Tindakan jika penyisipan data gagal
                        lblMessage.Text = "Failed to add invoice.";
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

    }
}