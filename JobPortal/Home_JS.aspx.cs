using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class Home_Employee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empid"] != null && Session["empid"].ToString() != "")
            {
                lblname.Text = Request.QueryString["pp"];
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }
    }
}