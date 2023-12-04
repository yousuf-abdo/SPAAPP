using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Net;

namespace SPAAPP
{
    public partial class wfForgetPassword1 : System.Web.UI.Page
    {
        cls_users us = new cls_users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Code"] != null && Session["Code"].ToString() == "code")
                {
                    Label1.Visible = true;
                    Label1.Text = "Reg ID";
                    TextBox1.Visible = true;
                    TextBox1.Text = "";


                    Label2.Visible = true;
                    Label2.Text = "new Password";
                    TextBox2.Visible = true;
                    TextBox2.Text = "";

                    Label3.Visible = true;
                    Label3.Text = "Confirm Password";
                    TextBox3.Visible = true;
                    TextBox3.Text = "";

                    Button1.Text = "Update Password";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userEmail, userFullName, userID, emailMessage;

            if (Session["Code"] == null)
            {
                DataTable dt = us.getAllUsersForPassword(TextBox1.Text);

                if (dt.Rows.Count == 1)
                {
                    userFullName = dt.Rows[0]["userName"].ToString();
                    userEmail = dt.Rows[0]["phEmail"].ToString();
                    userID = dt.Rows[0]["userID"].ToString();

                    int randNumber = getRandomNo();

                    emailMessage = "Hi   " + userFullName + " We snet this E-mail to help you to retrefe your SPA Account  password please re write this number (" + randNumber + " ) in web site and then Click OK to retrfe your password \n" +
                                                          "Thank you";
                    int res = us.updateUsersRanNumber(randNumber, userID);
                    if (res > 0)
                    {
                        //abdullazez1300@gmail.com
                        int emailRes = sendAnEmail("Yousuf.A.Komor@gmail.com", "Yousuf.A.Komor@gmail.com", "0909898216", "Retrefe SPA Account Password", emailMessage);
                        Response.Redirect("vNum.aspx");
                    }
                }
            }
            else
            {
                if (TextBox2.Text == TextBox3.Text)
                {
                    int res = us.updateUsersPassword(TextBox2.Text, TextBox1.Text);

                    if (res > 0)
                    {
                        Label4.Text = "Done Successfully";
                        Response.Redirect("2Login.aspx");
                    }
                    else
                    {
                        Label4.Text = "Error";
                    }
                }
                else
                {
                    Label4.Text = "password not matched Confirm password";
                }
            }
        }

        private int sendAnEmail(string TO, string myEmail, string myAccountPassword, string emailSubject, string mailbody)
        {
            /*
                To :
                From : +  my Password:
                Subject:
                Message(here is a random number):                
            */

            //bukidin MailMessage object
            MailMessage message = new MailMessage();

            //mail Subject section
            message.Subject = emailSubject;
            message.From = new MailAddress(myEmail);
            message.To.Add(TO);
            message.Body = mailbody;
            //mail Body section
            message.Body = mailbody;
            //encoding type       
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com"); //Gmail smtp    
            NetworkCredential basicCredential1 = new NetworkCredential(myEmail, myAccountPassword);
            //Secure Socket Layer is emabled[Optinal for security perpuses]
            client.Port = 587;                        
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                return 1;
            }

            catch (Exception e)
            {
                String err = e.ToString();
                return -1;
            }
        }

        private int getRandomNo()
        {
            Random r = new Random();
            int num = r.Next(1000000);
            return num;
        }
    }
}