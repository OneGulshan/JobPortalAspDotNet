using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class Home_Recruiter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rid"] != null && Session["rid"].ToString() != "")
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