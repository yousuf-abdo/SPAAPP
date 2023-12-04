using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPAAPP
{
    public partial class wfManage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("3wfPharmacies.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("4wfMidicines.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfRequestedMed.aspx");
        }
    }
}