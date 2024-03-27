using System;
using System.Web.UI;
using System.Net;
using System.Net.Mail;

namespace ProjectBatch1
{
    public partial class ApplyForm_JS : Page
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

        protected void Btn_sendemail_Click(object sender, EventArgs e)
        {
            MailAddress bcc = new MailAddress("gulshankumar.mailid01@gmail.com");
            using (MailMessage mm = new MailMessage(txtfromemail.Text, txttoemail.Text))
            {
                mm.Subject = txtsubject.Text;
                mm.Body = txtbody.Text;
                mm.CC.Add(bcc);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                NetworkCredential NetworkCred = new NetworkCredential(txtfromemail.Text, txtpassword.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Mail Send successfully');", true);
            }
        }
    }
}