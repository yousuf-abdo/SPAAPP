using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace SPAAPP
{
    public partial class wfRequestedMed : System.Web.UI.Page
    {
        cls_medicines  med = new cls_medicines();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvRequMed.DataSource = med.getAllReqMedicines();
                gvRequMed.DataBind();
            }
        }
        protected void gvRequMed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(Session["phID"]!= null)
            {
                string index = e.CommandArgument.ToString();                
                if (e.CommandName == "Button22")
                {
                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    //GridViewRow row = gvRequMed.Rows[int.Parse(index)-1];
                    string medName = row.Cells[2].Text;
                    Session["medName"] = medName;                
                    Response.Redirect("4wfMidicines.aspx");
                }
            }
        }
    }
}