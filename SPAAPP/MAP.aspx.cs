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
    public partial class MAP : System.Web.UI.Page
    {
        cls_pharmacies ph = new cls_pharmacies();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mapPhID = Request.QueryString["mapPhID"].ToString();
                //int phID = int.Parse(Session["mapPhID"].ToString());
                int phID = int.Parse(mapPhID);
                getMap(phID);
            }
        }
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

                GMap1.setCenter(mainLocation, 10);

                XPinLetter xpinLetter = new XPinLetter(PinShapes.pin, "U", Color.Red, Color.Blue, Color.Chocolate);

                GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

                //Declarations area
                PinIcon p;
                GMarker gm;
                GInfoWindow win;

                p = new PinIcon(PinIcons.medical, Color.Red);
                gm = new GMarker(new GLatLng(Convert.ToDouble(LocLat), Convert.ToDouble(LocLong)),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));

                win = new GInfoWindow(gm, "Pharmacy Name :" + phName + " Address :" + Location + " Phones :" + Phone1 + "  -  " + Phone2 + " E-mail" + phEmail, false, GListener.Event.mouseover);                
                //win = new GInfoWindow(gm, phName + " <a href='https://goo.gl/maps/u9G4JQtWPhvqymqQA'>Read more...</a>", false, GListener.Event.mouseover);
                GMap1.Add(win);

                //Session["mapPhID"] = null;
        }
    }
}