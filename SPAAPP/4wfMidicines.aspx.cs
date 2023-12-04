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
    public partial class wfMidiciness : System.Web.UI.Page
    {

        cls_medicines med = new cls_medicines();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["phID"] != null && Session["phID"].ToString() != "")
                {
                    if (Session["medName"] != null && Session["medName"].ToString() != "")
                    {
                        TextBox1.Text = Session["medName"].ToString();
                        TextBox1.Enabled = false;
                    }
                    else
                    {
                        GridView1.DataSource = med.getAllMedicinesByphID(Int32.Parse(Session["phID"].ToString()));
                        GridView1.DataBind();
                        TextBox1.Enabled = true;
                    }
                }
                else
                {
                    Response.Redirect("Login1.aspx");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "SAVE")
            {
                int res = med.addMedicines(TextBox1.Text, TextBox2.Text, TextBox3.Text, Session["phID"].ToString());

                if (res > 0)
                {
                    clearForm();
                    Label1.Text = "Inserted Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    fillGridView();
                    TextBox1.Enabled = true;
                }
                else
                {
                    Label1.Text = "Error..!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                string medID = HiddenField1.Value.ToString();
                int res = med.updateMedicines(TextBox1.Text, TextBox2.Text, TextBox3.Text, medID);

                if (res > 0)
                {
                    clearForm();
                    Label1.Text = "Updated Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;

                    fillGridView();
                }
                else
                {
                    Label1.Text = "Error..!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Label1.Text = "";
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string index = e.CommandArgument.ToString();
            if (e.CommandName == "Button22")
            {
                DataTable dt = med.getAllMedicinesByphmedID(Int32.Parse(index));

                Button1.Text = "UPDATE";

                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["medName"].ToString();
                    TextBox2.Text = dt.Rows[0]["medPrice"].ToString();
                    TextBox3.Text = dt.Rows[0]["medQuantaty"].ToString();
                    HiddenField1.Value = index;
                }
            }
            else if (e.CommandName == "Button33")
            {
                int res = med.deleteMedicines(Int32.Parse(index));

                if (res > 0)
                {
                    Label1.Text = "Medicine Deleted succefully...!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    fillGridView();
                }
                else
                {
                    Label1.Text = "Error in Deleting Medicine...!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }        
        private void fillGridView()
        {
            int phID = int.Parse(Session["phID"].ToString());

            DataTable dt = med.getAllMedicinesByphID(phID);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}