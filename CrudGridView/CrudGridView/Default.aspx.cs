using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CrudGridView
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionstring = @"Data Source=ANVESH\SQLSERVER; Integrated Security=true; Initial Catalog=PhoneBookDB";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridView();
            }
        }
        void PopulateGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from PhoneBook", con);
                da.Fill(dt);
            }
            if (dt.Rows.Count>0)
            {
                gvPhoneBook.DataSource = dt;
                gvPhoneBook.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPhoneBook.DataSource = dt;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void gvPhoneBook_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        sqlcon.Open();
                        string query = "insert into PhoneBook(FirstName,LastName,Contact,Email) values (@FirstName,@LastName,@Contact,@Email)";
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        cmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", (gvPhoneBook.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        cmd.ExecuteNonQuery();
                        PopulateGridView();
                        lblSuccessMessage.Text = "New Recored Added succrssfully";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
            
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    string query = "Update PhoneBook set FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Email=@Email where PhoneBookID=@id";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Recored Updated succrssfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    string query = "Delete from PhoneBook where PhoneBookID=@id";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Recored Deleted succrssfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}