using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPAAPP
{
    public partial class wfPharmaciesAdmin1 : System.Web.UI.Page
    {
        cls_pharmacies ph = new cls_pharmacies();
        cls_users us = new cls_users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["phID"] != null && Session["userID"] != null && Session["userType"] != null)
                {
                    if (bool.Parse(Session["userTYPE"].ToString()) == true)
                    {
                        fillGridView1();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
    {
            int chars = TextBox9.Text.IndexOf(",");
            string LocLat = TextBox9.Text.Substring(0, chars).Trim();
            int leng = TextBox9.Text.Length - chars - 1;
            string LocLong = TextBox9.Text.Substring(chars + 1, leng).Trim();

            if (Session["phID"] != null)
            {
                if (Button1.Text == "Save")
                {
                    int result = ph.addPharmacy(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, FileUpload1.FileName, LocLong, LocLat);

                    updateFileName();
                    if (result > 0)
                    {
                        int res2 = us.addUsers(TextBox7.Text, TextBox8.Text, result, TextBox6.Text);

                        if (res2 > 0)
                        {
                            Label1.Text = "Inserted Successfully";
                            Label1.ForeColor = System.Drawing.Color.Green;
                            fillGridView1();
                        }
                        else
                        {
                            Label1.Text = "Users Error..!";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        Label1.Text = "Pharmacy Error..!";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    int result = ph.updatePharmacy(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, FileUpload1.FileName, TextBox6.Text, HiddenField1.Value,LocLong,LocLat);
                    updateFileName();
                    if (result > 0)
                    {
                        int res2 = us.updateUsers(TextBox7.Text, TextBox8.Text, TextBox6.Text, HiddenField2.Value);

                        if (res2 > 0)
                        {
                            Label1.Text = "updated Successfully";
                            Label1.ForeColor = System.Drawing.Color.Green;
                            fillGridView1();
                        }
                        else
                        {
                            Label1.Text = "Users Error..!";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        Label1.Text = "Pharmacy Error..!";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                Label1.Text = "Error";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }       
        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }
        private void fillGridView1()
        {
            GridView1.DataSource = ph.getAllPharmacies1();
            GridView1.DataBind();
        }   
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)  
        {                        
            string index =  e.CommandArgument.ToString();            
            if (e.CommandName == "Button22")
            {
                Session["phIDAdmin"] = Session["phID"].ToString();
                Session["phID"] = index;
                Response.Redirect("4wfMidicines.aspx?phID=" + index);
            }
            else if (e.CommandName == "Button11")
            {
                DataTable dt = ph.getPharmacyForUpdate(Int32.Parse(index));
                DataTable dt1 = null;

                Button1.Text = "UPDATE";

                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["phName"].ToString();
                    TextBox2.Text = dt.Rows[0]["phLocation"].ToString();
                    TextBox3.Text = dt.Rows[0]["phPhone1"].ToString();
                    TextBox4.Text = dt.Rows[0]["phPhone2"].ToString();
                    TextBox5.Text = dt.Rows[0]["phEmail"].ToString();
                    TextBox6.Text = dt.Rows[0]["phRegister_ID"].ToString();
                    TextBox9.Text = dt.Rows[0]["LocLat"].ToString() + "," + dt.Rows[0]["LocLong"].ToString();
                    string regID = dt.Rows[0]["phRegister_ID"].ToString();
                    HiddenField1.Value = index;
                    FileUpload1.FileName.Equals(dt.Rows[0]["phImage_Path"].ToString());

                    dt1 = us.getAllUsersForPassword(regID);
                    if (dt1.Rows.Count > 0)
                    {
                        TextBox7.Text = dt1.Rows[0]["userNAME"].ToString();
                        TextBox8.Text = dt1.Rows[0]["userPASSWORD"].ToString();
                        HiddenField2.Value = dt1.Rows[0]["userID"].ToString();
                    }
                    Button1.Enabled = true;
                }
            }else if (e.CommandName == "Button33")
            {
                int res = ph.deletePharacy1(Int32.Parse(index));

                if(res > 0)
                {
                    fillGridView1();
                    Label1.Text = "Pharmacy Deleted Succufully...!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label1.Text = "Error deleting Pharmacy...!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private void updateFileName()
        {
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
            {
                //
                //get RigID as ImageName
                string newFilename = TextBox6.Text;

                //Get the file extension of the file being uploaded. 
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                //Combine the new filename and the extension. You want to make sure it's the same file extension.
                string updatedFilename = newFilename + fileExtension;

                //Set the upload location
                string SaveLocation = Server.MapPath("~/Images/Licenses/");
                bool hasErrors = false;

                try
                {
                    //Save the file to location with new filename
                    FileUpload1.SaveAs(Path.Combine(SaveLocation + updatedFilename));
                    hasErrors = false;
                }
                catch (Exception ex)
                {
                    //Display error if any
                    Label1.Text = "Error uploading file. " + ex.Message.ToString();
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Visible = true;
                    hasErrors = true;
                }
                finally
                {
                    //Do something or display success or failure
                    if (hasErrors == false)
                    {
                        Label1.Text = "File sucessfully uploaded with new filename: " + updatedFilename;
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Visible = true;
                    }
                }
            }
        }
    }
}