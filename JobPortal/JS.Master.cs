using System;

namespace JobPortal
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empid"] != null && Session["empid"].ToString() != "")
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