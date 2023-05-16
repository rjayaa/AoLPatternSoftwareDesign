using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testPOPUP
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void modal_Click(object sender, EventArgs e)
        {
            string script = "$('#mymodal').modal('show')";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
    }
}