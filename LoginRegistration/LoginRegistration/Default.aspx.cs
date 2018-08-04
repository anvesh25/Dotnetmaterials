using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LoginRegistration
{
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        private string message = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Attributes.Add("onclick", "javascript:return validate()");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text="";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtLocation.Text = "";
            txtCreatedBy.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MailMessage msg;
            SqlCommand cmd = new SqlCommand();
            string ActivationUrl = string.Empty;
            string emailId = string.Empty;
            try
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    string UserName = txtUserName.Text;
                    string Password = txtPassword.Text;
                    string ConfirmPassword = txtConfirmPassword.Text;
                    string FirstName = txtFirstName.Text;
                    string LastName = txtLastName.Text;
                    string Email = txtEmail.Text;
                    string Phoneno = txtPhoneNo.Text;
                    string Location = txtLocation.Text;
                    string Created_By = txtCreatedBy.Text;
                    int count = 0;
                    con = new SqlConnection("Data Source=ANVESH\\SQLSERVER;Initial Catalog=LoginRegister;Integrated Security=True");
                    con.Open();
                    cmd = new SqlCommand("sp_userinformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", ConfirmPassword);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@PhoneNo", Phoneno);
                    cmd.Parameters.AddWithValue("@Location", Location);
                    cmd.Parameters.AddWithValue("@Created_By", Created_By);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                    con.Close();
                    if (count > 0)
                    {
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtEmail.Text = "";
                        txtPhoneNo.Text = "";
                        txtLocation.Text = "";
                        txtCreatedBy.Text = "";
                    }
                    //Sending activation link in the email
                    msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    emailId = txtEmail.Text.Trim();
                    //sender email address
                    msg.From = new MailAddress("anveshbabu.26@gmail.com");
                    //Receiver email address
                    msg.To.Add(emailId);
                    msg.Subject = "Confirmation email for account activation";
                    ActivationUrl = Server.HtmlEncode("http://localhost:59862/LoginRegistration/ActivateAccount.aspx?UserID=" + FetchUserId(emailId) + "&Email=" + emailId);
                    msg.Body = "Hi " + txtFirstName.Text.Trim() + "!\n" + 
                        "Thanks for showing interest and registring in <a href='http://www.gmail.com'> Gmail.com<a> " + 
                        " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!";
                    msg.IsBodyHtml = true;
                    smtp.Credentials = new NetworkCredential("anveshbabu.26@gmail.com", "9014163856");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Send(msg);
                    clear_controls();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Confirmation Link to activate your account has been sent to your email address');", true);
                }
                else
                {
                    Page.RegisterStartupScript("UserMsg", "<Script language='javascript'>alert('" + "Password mismatch" + "');</script>");
                }
                lblErrorMsg.Text = message;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                return;
            }
            finally
            {
                ActivationUrl = string.Empty;
                emailId = string.Empty;
                con.Close();
                cmd.Dispose();
            }
        }

        private void clear_controls()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtLocation.Text = "";
            txtCreatedBy.Text = "";
        }

        private string FetchUserId(string emailId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT UserName FROM User_Information WHERE Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", emailId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string UserID = "";
            UserID=Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd.Dispose();
            return UserID;
        }
    }
}