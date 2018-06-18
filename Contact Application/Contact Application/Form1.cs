using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Contact_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=ANVESH\\SQLSERVER;initial catalog=contactApp;integrated security=true");
            SqlCommand cmd = new SqlCommand("insert into empcontact values('" + txtName.Text + "','" + txtPhoneNo.Text + "', '" + txtEmail.Text + "', '" + txtCompany.Text + "', '" + txtAddress.Text+ "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record inserted successfully");
            con.Close();
            txtName.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtCompany.Text = "";
            txtAddress.Text = "";
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=ANVESH\\SQLSERVER;initial catalog=contactApp;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from empcontact where phoneno='"+txtPhoneNo.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted successfully");
            con.Close();
            txtName.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtCompany.Text = "";
            txtAddress.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=ANVESH\\SQLSERVER;initial catalog=contactApp;integrated security=true");
            SqlCommand cmd = new SqlCommand("update empcontact set name='" + txtName.Text + "', emaiid='" + txtEmail.Text + "', company='" + txtCompany.Text + "', address='"+txtAddress.Text+"' where phoneno='" + txtPhoneNo.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated successfully");
            con.Close();
            txtName.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtCompany.Text = "";
            txtAddress.Text = "";
        }
    }
}
