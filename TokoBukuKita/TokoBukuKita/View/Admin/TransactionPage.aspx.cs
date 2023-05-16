using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBukuKita.Repository;
using TokoBukuKita.Model;
namespace TokoBukuKita.View.Admin
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Mendapatkan tombol "Create Transaction" yang diklik
            Button btnView = (Button)sender;

            // Mendapatkan baris GridView yang mengandung tombol tersebut
            GridViewRow row = (GridViewRow)btnView.NamingContainer;

            // Mendapatkan data dari baris GridView yang dipilih
            string customerID = row.Cells[0].Text;
            string customerName = row.Cells[1].Text;
            string customerAddress = row.Cells[2].Text;
            string customerPhone = row.Cells[3].Text;
            string customerEmail = row.Cells[4].Text;

            // Mengisi nilai TextBox pada modal popup dengan data yang diperoleh
            txtCustomerID.Text = customerID;
            txtName.Text = customerName;
       

            // Menampilkan modal popup
            string script = @"<script type='text/javascript'>
                        $(document).ready(function () {
                            $('#mymodal').modal('show');
                        });
                    </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "ModalScript", script);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Mendapatkan nilai dari TextBox pada modal popup
            //string name = txtName.Text;
            //string email = txtmail.Text;
            //string contact = txtcontact.Text;
            //string address = txtaddress.Text;

            // Lakukan operasi penyimpanan atau manipulasi data sesuai kebutuhan
            // ...

            // Menutup modal popup setelah selesai
            string script = @"<script type='text/javascript'>
                            $(document).ready(function () {
                                $('#mymodal').modal('hide');
                            });
                        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseModalScript", script);

            // Refresh GridView
            BindGridView();
        }

        private void BindGridView()
        {
            // Mendapatkan data customer dari Repository
            var customers = Repository.Repository.getCustomer();

            // Mengikat data ke GridView
            gridViewCustomer.DataSource = customers;
            gridViewCustomer.DataBind();
        }

    }
}