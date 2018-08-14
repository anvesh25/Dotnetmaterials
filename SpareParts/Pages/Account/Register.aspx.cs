using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
//using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["GarageDbConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        //Create new user and try to store in DB
        IdentityUser user = new IdentityUser();
        user.UserName = txtUserName.Text;

        if(txtPassword.Text==txtConfirmPassword.Text)
        {
            try
            {
                //Create user object.
                //IdentityResult result = manager.Create(user, txtPassword.Text);
                IdentityResult result = manager.Create(user, txtPassword.Text);
                if (result.Succeeded)
                {
                    UserInformation info = new UserInformation
                    {
                        Address=txtAddress.Text,
                        FirstName=txtFirstName.Text,
                        LastName=txtLastName.Text,
                        PostalCode=Convert.ToInt32(txtPostalCode.Text),
                        GUID=user.Id
                    };

                    UserInfoModel model = new UserInfoModel();
                    model.InsertUserInformation(info);

                    //Store user in db
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    //set to log in new user by cookie
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //Login the new user and redirect to homepage
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    litStatus.Text = result.Errors.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                litStatus.Text = ex.ToString();
            }
        }
        else
        {
            litStatus.Text="Password and Confirm Password must match";
        }
    }
}