using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
namespace TokoBuku.Roles.Admin.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCustomerIDs.Text = Request["ID"];
                bindGridViewBook();
            }
        }

        private void bindGridViewBook()
        {
            var bk = Repository.Repository.getBook();
            gridViewBook.DataSource = bk;
            gridViewBook.DataBind();
        }
        protected void gridViewBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
              
                gridViewBook.SelectedIndex = rowIndex; // Mengatur baris terpilih di GridView
                string script = "$('#mymodal').modal('show')";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
               
            }
        }

        

        protected void btnAdd_Click(object sender, EventArgs e)
        {           
            int rowIndex = gridViewBook.SelectedIndex;
            int stock = GetStockValue(rowIndex);

            int userInput = Convert.ToInt32(txtQuantity.Text);

           
            if (userInput <= stock)
            {
                string script = @"<script type='text/javascript'>
                            $('#ValidationModal').modal('show');
                        </script>";
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowSuccessModalScript", script, false);
                txtValidation.Text = "Data Insert Success!!";
            }
            else if(userInput > stock)
            {
                string script = @"<script type='text/javascript'>
                            $('#ValidationModal').modal('show');
                        </script>";
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowSuccessModalScript", script, false);
                txtValidation.Text = "Data Failed!";
            }
            txtQuantity.Text = "";

        }
        private int GetStockValue(int rowIndex)
        {
            // Mendapatkan nilai "Stock" dari kolom GridView
            if (rowIndex >= 0 && rowIndex < gridViewBook.Rows.Count)
            {
                GridViewRow selectedRow = gridViewBook.Rows[rowIndex];
                string stockText = selectedRow.Cells[6].Text; // Mengambil teks dari sel pada indeks kolom ke-7

                int stock;
                if (int.TryParse(stockText, out stock))
                {
                    return stock;
                }
            }
            return 0; // Jika indeks baris tidak valid atau konversi gagal
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}