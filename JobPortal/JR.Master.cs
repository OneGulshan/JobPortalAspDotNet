using System;
using System.Web.UI;

namespace JobPortal
{
    public partial class Recruiter1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rid"] != null && Session["rid"].ToString() != "")
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