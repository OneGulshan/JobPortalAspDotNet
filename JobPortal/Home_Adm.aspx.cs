using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class Home_Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["aid"] != null && Session["aid"].ToString() != "")
            {
                //code
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }
    }
}