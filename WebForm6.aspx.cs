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
    public partial class WebForm6 : System.Web.UI.Page
    {

        private void GridviewDisplay()
        {
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            string query = "select * from HotelRegistration";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            if (Session["WelcomeMessage"] != null)
            {
                Label1.Text = Session["WelcomeMessage"].ToString();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridviewDisplay();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            Label lbl = (Label)rows.FindControl("Label1");
            string query = "delete from HotelRegistration where UserName='" + lbl.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GridviewDisplay();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridviewDisplay();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            SqlConnection conn = new SqlConnection("data source=BADRIYADAV;database=ADO.NET;integrated security=yes");
            conn.Open();
            TextBox t1 = (TextBox)rows.FindControl("TextBox1");
            TextBox t2 = (TextBox)rows.FindControl("TextBox2");
            TextBox t3 = (TextBox)rows.FindControl("TextBox3");
            var query = "UPDATE HotelRegistration SET RoomType = '" + t2.Text + "', Amenities = '" + t3.Text + "' WHERE UserName = '" + t1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            conn.Close();
            GridviewDisplay();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridviewDisplay();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm7.aspx");
        }
    }
}
        