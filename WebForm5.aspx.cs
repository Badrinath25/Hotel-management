using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string UserName = TextBox1.Text;
            string RoomType = "";
            string Amenities ="";
            if (CheckBox1.Checked==true)
            {
                Amenities = Amenities + CheckBox1.Text+"";
            }
            if (CheckBox2.Checked)
            {
                Amenities = Amenities + CheckBox2.Text+"";
            }
            if(CheckBox1.Checked==false&&CheckBox2.Checked==false)
            {
                Amenities=TextBox1.Text+"Please select one checkbox";
            }
            if (RadioButton1.Checked == true)
            {
                RoomType = "Delux";
            }
            if (RadioButton2.Checked == true)
            {
                RoomType = "Ordinary";
            }
            Label4.Text = UserName + ", You Have To Select a Room Type and Amenities.";
            string WelcomeMessage = "Welcome " + UserName +"<br/>"+" You Have Selected " + RoomType + " And " + Amenities;
            Session["WelcomeMessage"] = WelcomeMessage;
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            string query = "SELECT COUNT (*) FROM HotelRegistration WHERE UserName=@username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", UserName);
            int usercount = (int)cmd.ExecuteScalar();
            if (UserName==TextBox1.Text)
            {
                string insertquery = "INSERT INTO HotelRegistration VALUES('" + UserName + "','" + RoomType + "','" + Amenities + "')";
                SqlCommand add = new SqlCommand(insertquery, conn);
                add.ExecuteNonQuery();
                Response.Redirect("WebForm6.aspx");
            }
            else
            {
                Label4.Text = "User Not Found!!";
            }
            conn.Close();
        }
    }
}