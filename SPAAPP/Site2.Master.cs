using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPAAPP
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["userTYPE"] == null || Session["userID"] == null || Session["phID"] == null)
            //    {
            //        Response.Redirect("Login1.aspx");
            //    }
            //}
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {            
                    Session["userTYPE"] = null;
                    Session["userID"] = null;
                    Session["phID"] = null;
                    Response.Redirect("1SPA.aspx");               
        }
    }
}