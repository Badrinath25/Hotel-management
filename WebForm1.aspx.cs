using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string FirstName = TextBox1.Text;
            string LastName = TextBox2.Text;
            string UserName = TextBox3.Text;
            string Gender = RadioButton1.Checked ? "Male" : (RadioButton2.Checked ? "Female" : null);
            string Password = TextBox5.Text;
            string ConfirmPassword = TextBox6.Text;
            string Email = TextBox7.Text;
            string PhoneNum = TextBox8.Text;
            string Address = TextBox9.Text;
            string LanguagesKnown = " ";
            string Country = DropDownList1.SelectedValue;
            int Age = 0;
            if (!int.TryParse(TextBox10.Text, out Age))
            {
                Label11.Text = "Please enter a valid age.";
                return;
            }
            if (int.TryParse(TextBox10.Text, out Age))
            {

            }
            else
            {
                Response.Write("Please Enter a VAlid Age...");
            }
            if (CheckBox1.Checked) LanguagesKnown += "Telugu";
            if (CheckBox2.Checked) LanguagesKnown += "English";
            if (CheckBox3.Checked) LanguagesKnown += "Hindi";
            LanguagesKnown = LanguagesKnown.Trim();
            if (Password != ConfirmPassword)
            {
                Response.Write("Passwords do not match.");
            }
            if (Password == ConfirmPassword)
            {
                Response.Write("Data successfully Inserted!!");
            }
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            string Query = "INSERT INTO UserRegistration VALUES('" + FirstName + "','" + LastName + "','" + UserName + "','" + Gender + "','" + Password + "','" + ConfirmPassword + "','" + Email + "','" + PhoneNum + "','" + Address + "'," + Age + ",'" + LanguagesKnown + "','" + Country + "')";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("WebForm2.aspx");
        }
    }
}