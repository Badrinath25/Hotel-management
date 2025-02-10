using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private void GridviewDisplay1()
        {
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            string query = "select * from UserRegistration";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                adapter.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("No data found.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridviewDisplay1();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            Label lbl = (Label)rows.FindControl("Label1");
            string query = "delete from UserRegistration where FirstName='" + lbl.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GridviewDisplay1();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridviewDisplay1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            
            TextBox t1 = (TextBox)row.FindControl("TextBox1");
            TextBox t2 = (TextBox)row.FindControl("TextBox2");
            TextBox t3 = (TextBox)row.FindControl("TextBox3");
            TextBox t4 = (TextBox)row.FindControl("TextBox4");
            TextBox t5 = (TextBox)row.FindControl("TextBox5");
            TextBox t6 = (TextBox)row.FindControl("TextBox6");
            TextBox t7 = (TextBox)row.FindControl("TextBox7");
            TextBox t8 = (TextBox)row.FindControl("TextBox8");
            TextBox t9 = (TextBox)row.FindControl("TextBox9");
            TextBox t10 = (TextBox)row.FindControl("TextBox10");
            TextBox t11 = (TextBox)row.FindControl("TextBox11");
            TextBox t12 = (TextBox)row.FindControl("TextBox12");
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            var query= "UPDATE UserRegistration SET LastName='"+t2.Text+ "', UserName='" + t3.Text + "',Gender='" + t4.Text + "',Password='" + t5.Text + "',ConfirmPassword='" + t6.Text + "',Email='" + t7.Text + "',PhoneNum='" + t8.Text + "',Address='" + t9.Text + "',Age='" + t10.Text + "',LanguagesKnown='" + t11.Text + "',Country='" + t12.Text + "' WHERE FirstName='" + t1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            conn.Close();
            GridviewDisplay1();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridviewDisplay1();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm5.aspx");
        }
    }
}