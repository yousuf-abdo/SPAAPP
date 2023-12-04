using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SPAAPP
{
    public partial class wfRequestedMedAdmin : System.Web.UI.Page
    {
        cls_medicines med = new cls_medicines();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }
        }
        protected void gvRequMed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["phID"] != null)
            {
                string index = e.CommandArgument.ToString();
                if (e.CommandName == "Button22")
                {
                    int res = med.deleteReqMedicines(int.Parse(index));
                    if(res > 0)
                    {
                        Label1.Text = "Request Deleted Successfuly";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        FillGridView();
                    }
                    else
                    {
                        Label1.Text = "Delete Error";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        private void FillGridView()
        {
            gvRequMed.DataSource = med.getAllReqMedicines();
            gvRequMed.DataBind();
        }
    }
}