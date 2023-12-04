using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace SPAAPP
{
    public partial class SPA2 : System.Web.UI.Page
    {
        cls_medicines med = new cls_medicines();
        cls_pharmacies ph = new cls_pharmacies();
        DataTable dtSearch = new DataTable();
        string phName;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            String loc = TextBox1.Text.ToString();
            String loc1 = loc;            
          
            if (!IsPostBack)
            {                
                DropDownList1.DataSource = ph.getAllPharmacies1();
                DropDownList1.DataValueField = "Name";
                DropDownList1.DataTextField = "Name";
                                
                ListItem item = new ListItem("-Select Pharmacy Name -", "-1");
                
                DropDownList1.DataBind();
              
                DropDownList1.Items.Add(item);
                DropDownList1.SelectedValue = "-1";

                if (!IsPostBack)
                {
                    ViewState["medName"] = "med";
                }
            }
        }    
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ViewState["medName"].ToString() == "ph")
            {                
                if (DropDownList1.SelectedValue.ToString().Equals("-1"))
                {
                    Label1.Text = "Please Select Pharmacy Name";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                else
                {
                    dtSearch = med.SearchMed(phName, "phNAME");

                    if (dtSearch.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtSearch;
                        GridView1.DataBind();
                        hylReq.Visible = false;
                        ViewState["mapPhID"] = dtSearch.Rows[0]["phID"].ToString();
                        Session["mapPhID"] = dtSearch.Rows[0]["phID"].ToString();
                                                
                        Label1.Text = "";
                        TextBox1.Text = "";                        
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        Label1.Text = "OOp's No Data Found please try again later";
                        Label1.ForeColor = System.Drawing.Color.Red;                       
                    }
                }
            }
            else
            {
                dtSearch = med.SearchMed(TextBox1.Text, "medNAME");

                if (dtSearch.Rows.Count > 0)
                {
                    GridView1.DataSource = dtSearch;
                    GridView1.DataBind();
                    hylReq.Visible = false;
                    ViewState["mapPhID"] = dtSearch.Rows[0]["phID"].ToString();
                    Session["mapPhID"] = dtSearch.Rows[0]["phID"].ToString();
                    Label1.Text = "";
                    TextBox1.Text = "";
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    
                    Label1.Text = "OOp's No Data Found please try again later";
                    hylReq.Visible = true;
                    lblReqMedName.Text = "Hellow dear customer we are so sorry because you didn't find the Medicine \n so we will notify the pharmasists that there was A Requested Medicine which is (" + TextBox1.Text +") Please insert you Phone Number to contcat with you when A requested Medicene ";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (ViewState["medName"].ToString() == "ph")
            {
                ViewState["medName"] = "med";
                DropDownList1.Visible = false;
                TextBox1.Visible = true;
                TextBox1.Text = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                Label1.Text = "";
                LinkButton1.Text = "By Pharmacy";
                GMap1.Visible = false;
                hylReq.Visible = false;
            }
            else
            {
                ViewState["medName"] = "ph";
                DropDownList1.Visible = true;
                TextBox1.Visible = false;
                TextBox1.Text = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                Label1.Text = "";
                LinkButton1.Text = "By Medicine";
                GMap1.Visible = false;
                hylReq.Visible = false;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GMap1.Visible = false;
            phName = DropDownList1.SelectedValue.ToString();                                                
        }
        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Login.aspx");
        //    GMap1.Visible = false;
        //}
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string index = e.CommandArgument.ToString();
            if (e.CommandName == "Button22")
            {
                if (IsPostBack)
                {
                    //int phID = Int32.Parse(ViewState["mapPhID"].ToString());                   
                    int phID = int.Parse(index);
                    if (phID > 0)
                    {
                        Response.Redirect("MAP.aspx?mapPhID="+phID);
                        //Session["mapPhID"] = phID;
                        //Response.Redirect("MAP.aspx");
                    }
                    else
                    {
                        GMap1.Visible = false;
                        Label1.Text = "Error";
                    }
                }
            }
        }

        /******************************************************** For Map Usage ******************************************************************************************/
        private void getMap()
        {
            DataTable dtMap = ph.getAllPharmacies();
            
            GLatLng mainLocation = new GLatLng(15.614066566481894, 32.48410483575854);
            GMap1.setCenter(mainLocation, 15);
            
            XPinLetter xpinLetter = new XPinLetter(PinShapes.pin, "H", Color.Red, Color.Blue, Color.Chocolate);

            GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));            

            PinIcon p;
            GMarker gm;
            GInfoWindow win;
            foreach (var i in dtMap.Rows)
            {
                string LocLat = dtMap.Rows[0]["LocLat"].ToString();
                string LocLong = dtMap.Rows[0]["LocLong"].ToString();
                string phName = dtMap.Rows[0]["phName"].ToString();
                string Location = dtMap.Rows[0]["phLocation"].ToString();
                string Phone1 = dtMap.Rows[0]["phPhone1"].ToString();
                string Phone2 = dtMap.Rows[0]["phPhone2"].ToString();
                string phEmail = dtMap.Rows[0]["phEmail"].ToString();

                p = new PinIcon(PinIcons.medical, Color.Red);
                gm = new GMarker(new GLatLng(Convert.ToDouble(LocLat), Convert.ToDouble(LocLong)),
                         new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));

                win = new GInfoWindow(gm, "Pharmacy Name :" + phName + " \n  Address :" + Location + " \n Phons :" + Phone1 + "  -  " + Phone2 + " \n   E-mail" + phEmail, false, GListener.Event.mouseover);
                //win = new GInfoWindow(gm, HotelName + " <a href='" + ReadMoreUrl + "'>Read more...</a>", false, GListener.Event.mouseover);
                GMap1.Add(win);
            }
        }
        private void getMap(int phID)
        {            
                DataTable dtMap = ph.getAllPharmacies(phID);
                string LocLat = dtMap.Rows[0]["LocLat"].ToString();
                string LocLong = dtMap.Rows[0]["LocLong"].ToString();
                string phName = dtMap.Rows[0]["phName"].ToString();
                string Location = dtMap.Rows[0]["phLocation"].ToString();
                string Phone1 = dtMap.Rows[0]["phPhone1"].ToString();
                string Phone2 = dtMap.Rows[0]["phPhone2"].ToString();
                string phEmail = dtMap.Rows[0]["phEmail"].ToString();

                GLatLng mainLocation = new GLatLng(double.Parse(LocLat), double.Parse(LocLong));

                GMap1.setCenter(mainLocation, 15);

                XPinLetter xpinLetter = new XPinLetter(PinShapes.pin, "U", Color.Red, Color.Blue, Color.Chocolate);

                GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

                //Declarations area
                PinIcon p;
                GMarker gm;
                GInfoWindow win;

                p = new PinIcon(PinIcons.medical, Color.Red);
                gm = new GMarker(new GLatLng(Convert.ToDouble(LocLat), Convert.ToDouble(LocLong)),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));

                //win = new GInfoWindow(gm, "Pharmacy Name :" + phName + " \n  Address :" + Location + " \n Phons :" + Phone1 + "  -  " + Phone2 + " \n   E-mail" + phEmail, false, GListener.Event.mouseover);
                win = new GInfoWindow(gm, "Pharmacy Name :" + phName + "<a   href='https://goo.gl/maps/yZQZp9MHxJsjLFC79'> Read more...</a>", false, GListener.Event.mouseover);
                GMap1.Add(win);            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!txtReqTel.Text.Equals("") && !TextBox1.Text.Equals(""))
            {
                int res = med.addReqMedicine(TextBox1.Text, txtReqTel.Text);
                if(res > 0)
                {
                    TextBox1.Text = "";
                }
            }            
        }
    }
}