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
    public partial class wfPharmacies1 : System.Web.UI.Page
    {
        cls_pharmacies ph = new cls_pharmacies();
        cls_users us = new cls_users();
        string updatedFilename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["phID"] != null)
                {
                    int phID = int.Parse(Session["phID"].ToString());

                    DataTable dt = ph.getPharmacyForUpdate(phID);

                    if (dt.Rows.Count > 0)
                    {
                        TextBox1.Text = dt.Rows[0]["phName"].ToString();
                        TextBox2.Text = dt.Rows[0]["phLocation"].ToString();
                        TextBox3.Text = dt.Rows[0]["phPhone1"].ToString();
                        TextBox4.Text = dt.Rows[0]["phPhone2"].ToString();
                        TextBox5.Text = dt.Rows[0]["phEmail"].ToString();
                        TextBox6.Text = dt.Rows[0]["phRegister_ID"].ToString();
                        TextBox7.Text = dt.Rows[0]["userNAME"].ToString();
                        TextBox8.Text = dt.Rows[0]["userPASSWORD"].ToString();
                        TextBox9.Text = dt.Rows[0]["LocLat"].ToString() + "," + dt.Rows[0]["LocLong"].ToString();
                        Button1.Text = "Update";
                    }
                }
                else
                {
                    clearForm();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int chars = TextBox9.Text.IndexOf(",");
            string LocLat = TextBox9.Text.Substring(0, chars).Trim();
            int leng = TextBox9.Text.Length - chars-1;
            string LocLong = TextBox9.Text.Substring(chars+1,  leng).Trim();

            if (Session["phID"] == null && Session["userID"] == null)
            {                
                int result = ph.addPharmacy(TextBox1.Text ,TextBox2.Text ,TextBox3.Text ,TextBox4.Text ,TextBox5.Text ,TextBox6.Text ,updateFileName(),LocLat ,LocLong);
                updateFileName();
                if (result > 0)
                {
                    int res2 = us.addUsers(TextBox7.Text, TextBox8.Text, result, TextBox6.Text);

                    if (res2 > 0)
                    {
                        Label1.Text = "Inserted Successfully";                        
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("2Login.aspx");
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
                int result = ph.updatePharmacy(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, updateFileName(), TextBox6.Text, Session["phID"].ToString(), LocLong ,LocLat);
                updateFileName();
                if (result > 0)
                {
                    int res2 = us.updateUsers(TextBox7.Text, TextBox8.Text, TextBox6.Text, Session["userID"].ToString());

                    if (res2 > 0)
                    {
                        Label1.Text = "updated Successfully";                        
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("2Login.aspx");
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

        private string updateFileName()
        {
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
            {
                //
                //get RigID as ImageName
                string newFilename = TextBox6.Text;

                //Get the file extension of the file being uploaded. 
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                //Combine the new filename and the extension. You want to make sure it's the same file extension.
                updatedFilename = newFilename + fileExtension;

                //Set the upload location
                string SaveLocation = Server.MapPath("~/Images/Licenses/");
                bool hasErrors = false;

                try
                {
                    //Save the file to location with new filename
                    FileUpload1.SaveAs(Path.Combine("Images/Licenses/" + updatedFilename));
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
            return updatedFilename;
        }
    }
}