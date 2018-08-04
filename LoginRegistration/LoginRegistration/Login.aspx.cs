using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace LoginRegistration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                rfvUserName.Visible=true;
            }
            else if(txtPassword.Text=="")
            {
                rfvPassword.Visible = true;
            }
            else if (txtUserName.Text == "" && txtPassword.Text == "")
            {
                rfvUserName.Visible = true;
                rfvPassword.Visible = true;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=ANVESH\\SQLSERVER;Initial Catalog=LoginRegister;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from User_Information where UserName =@UserName and Password=@Password", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}