using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserName = TextBox1.Text;
            string Password = TextBox2.Text;
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM UserRegistration WHERE UserName = '" + UserName.Replace("'", "''") + "' AND Password = '" + Password.Replace("'", "''") + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    Response.Write("LogIn Successfully");
                    Response.Redirect("WebForm1.aspx");
                }
                else
                {
                    Response.Write("Invalid Username or Password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}