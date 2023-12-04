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
    public partial class Login1 : System.Web.UI.Page
    {
        cls_users us = new cls_users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Focus();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtUser = us.Login(TextBox1.Text, TextBox2.Text);

            if (dtUser.Rows.Count > 0)
            {
                Session["userTYPE"] = dtUser.Rows[0]["userTYPE"].ToString();
                Session["userID"] = dtUser.Rows[0]["userID"].ToString();
                Session["phID"] = dtUser.Rows[0]["phID"].ToString();

                if (bool.Parse(Session["userTYPE"].ToString()) == true)
                {
                    Response.Redirect("wfPharmaciesAdmin.aspx");
                }
                else
                {
                    Response.Redirect("4wfManage.aspx");
                }

            }
            else
            {
                Label1.Text = "Login Error";
                Label1.ForeColor = System.Drawing.Color.Red;
                ClearForm();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {            
            ClearForm();
            Response.Redirect("1SPA.aspx");
        }
        
        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["phID"] = null;
            Response.Redirect("3wfPharmacies.aspx");
        }
    }
}