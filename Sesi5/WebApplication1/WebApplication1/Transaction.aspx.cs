using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;
namespace WebApplication1
{
    public partial class Transaction : System.Web.UI.Page
    {

        // Deklarasi List
        public List<transaction> transactions = new List<transaction>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Manggil transaction
            transactions = TransactionRepository.GetTransactions();
        }
    }
}