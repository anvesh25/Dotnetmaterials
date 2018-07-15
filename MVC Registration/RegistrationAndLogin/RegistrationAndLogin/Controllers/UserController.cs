using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Web.Security;

namespace RegistrationAndLogin.Controllers
{
    public class UserController : Controller
    {
        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified, ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";

            //Model validation
            if(ModelState.IsValid)
            {
                #region//Email alreadyexist
                var isExist = isEmailExist(user.EmailId);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email is already exist");
                    return View(user);
                }
                #endregion

                #region//Generate activation code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region //Password Hashing
                user.Password = Crypto.Mash(user.Password);
                user.ConfirmPassword = Crypto.Mash(user.ConfirmPassword);
                #endregion
                user.IsEmailVerified = false;

                #region //Save dataBase
                using (MyDataBaseEntities dc = new MyDataBaseEntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send email to user
                    SendVerificationLinkEmail(user.EmailId, user.ActivationCode.ToString());
                    message = "Registration successfully done. Activation link has been to your email id:" + user.EmailId;
                    Status = true;
                }

                #endregion

            }
            else
            {
                message = "Invalid request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        //Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (MyDataBaseEntities dc = new MyDataBaseEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;  //This is the line i have added here to avoid confirm password does not match issue on save changes
                var v = dc.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v!=null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
                return View();
        }
        
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //login post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string message = "";
            using (MyDataBaseEntities dc = new MyDataBaseEntities())
            {
                var v = dc.Users.Where(a => a.EmailId == login.EmailID).FirstOrDefault();
                if (v!= null)
                {
                    if(string.Compare(Crypto.Mash(login.Password), v.Password)==0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid Credentials provided";
                    }
                }
                else
                {
                    message = "Invalid Credentials provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool isEmailExist(string emailID)
        {
            using (MyDataBaseEntities ds = new MyDataBaseEntities())
            {
                var v = ds.Users.Where(a => a.EmailId == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("anveshbabu.26@gmail.com", "MVC Learning");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "9014163856";
            string subject = "Yourt account is successfully created";

            string body = "<br /><br />Erare exited to tell you that your MVC learning account is" +
                " Successfully creaed. Please click on the below link to verify your account" +
                " <br /><br /><a href='" + link + "'>" + link + "</a>";
             
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(message);
        }
    }
}