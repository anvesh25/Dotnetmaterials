using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistration
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ActivateMyAccount();
            }
        }
        private void ActivateMyAccount()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con = new SqlConnection("Data Source=ANVESH\\SQLSERVER;Initial Catalog=LoginRegister;Integrated Security=True");
                if ((!string.IsNullOrEmpty(Request.QueryString["UserName"])) & (!string.IsNullOrEmpty(Request.QueryString["Email"])))
                {
                    //approve account by setting Is_Approved to 1 i.e. True in the sql server table
                    cmd = new SqlCommand("UPDATE Tb_Registration SET Is_Approved=1 WHERE UserName=@UserName AND Email=@Email", con);
                    cmd.Parameters.AddWithValue("@UserName", Request.QueryString["UserName"]);
                    cmd.Parameters.AddWithValue("@Email", Request.QueryString["Email"]);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    Response.Write("You account has been activated. You can <a href='Login.aspx'>Login</a> now! ");
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + e.Message.ToString() + "');", true);
                return;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
    }
}