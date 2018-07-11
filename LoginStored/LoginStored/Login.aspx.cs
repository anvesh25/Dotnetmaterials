using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LoginStored
{
    public partial class Login : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        SqlParameter sp1 = new SqlParameter();
        SqlParameter sp2 = new SqlParameter();
        SqlParameter sp3 = new SqlParameter();
        SqlParameter sp4 = new SqlParameter();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=ANVESH\\SQLSERVER;initial catalog=contactApp;integrated security=true");
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value =txtId;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword;
            cmd.Parameters.Add("@ConfirmPassword", SqlDbType.VarChar).Value = txtConfirmPassword;
            cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = txtEmailId;
            cmd = new SqlCommand("SubmitLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}