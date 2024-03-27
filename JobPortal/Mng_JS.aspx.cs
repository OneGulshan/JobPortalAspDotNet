using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JobPortal
{
    public partial class Mng_Emp : Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["aid"] != null && Session["aid"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }

        public void BindData()
        {
            SqlCommand cmd = new SqlCommand("sp_Employee", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@mode", 2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();            
        }

        protected void Grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "APR")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@mode", 14);
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindData();
            }
        }

        protected void Btnsearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mode", 11);
            cmd.Parameters.AddWithValue("@search", txtsearch.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
                lblmsg.Text = "";
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
                lblmsg.Text = "No Record Search !!";
            }
        }
    }
}