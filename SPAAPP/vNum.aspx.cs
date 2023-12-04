using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SPAAPP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        cls_users us = new cls_users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtNumber = us.validateNumber(TextBox1.Text);

            if (dtNumber.Rows.Count > 0)
            {
                Session["Code"] = "code";
                Response.Redirect("5wfForgetPassword.aspx");
            }
        }
    }
}