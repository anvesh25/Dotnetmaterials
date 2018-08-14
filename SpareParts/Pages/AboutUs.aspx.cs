using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;

public partial class Pages_AboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" && txtEmail.Text != "" && txtSubject.Text != "" && txtMessage.Text != "")
        {
            try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(txtEmail.Text);
                // Recipient e-mail address.
                Msg.To.Add("unnamanveshbabu.26@gmail.com");
                Msg.Subject = txtSubject.Text;
                Msg.Body = txtMessage.Text;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("anveshbabu.26@gmail.com", "9014163856");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                //Msg = null;
                lbltxt.Text = "Thanks for Contact us";
                // Clear the textbox valuess
                txtName.Text = "";
                txtSubject.Text = "";
                txtMessage.Text = "";
                txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                lbltxt.Text = "Email Id provided is invalid";
                lbltxt.ForeColor = Color.Red;
                txtEmail.BorderColor = Color.Red;
            }
        }
        else
        {
            if (txtName.Text == "")
            {
                txtName.BorderColor = Color.Red;
            }
            if (txtEmail.Text=="")
            {
                txtEmail.BorderColor = Color.Red;
            }
            if (txtMessage.Text == "")
            {
                txtMessage.BorderColor = Color.Red;
            }
            if (txtSubject.Text == "")
            {
                txtSubject.BorderColor = Color.Red;
            }

        }
        
    }
}