using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace payu_bolt
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            dvbody.InnerHtml = "<h2>I STAND FOR THE NATION Payment Response</h2>";
            dvbody.InnerHtml += "Txnid: " + Request.Form["txnid"] + "<br />";
            dvbody.InnerHtml += "Amount: " + Request.Form["amount"] + "<br />";
            dvbody.InnerHtml += "First Name: " + Request.Form["firstname"] + "<br />";
            dvbody.InnerHtml += "Email: " + Request.Form["email"] + "<br />";
            dvbody.InnerHtml += "Myhpayid: " + Request.Form["mihpayid"] + "<br />";
            dvbody.InnerHtml += "Status: " + Request.Form["status"] + "<br />";
            string status = Request.Form["status"].ToString();
            string email = Request.Form["email"].ToString();
            string name = Request.Form["firstname"].ToString();
            if (status == "success")
            {
                try
                {
                    string GmailUsername = "thankyou@istandforthenation.org";
                    string GmailPassword = "mGQ=5eRh";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "relay-hosting.secureserver.net"; //godaddy
                                                                  //   smtp.Host = "smtp.gmail.com"; //localhost
                    smtp.Port = 25;
                    // smtp.EnableSsl = true; //localhost
                    smtp.EnableSsl = false;//godaddy
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    // smtp.UseDefaultCredentials = true;//localhost
                    smtp.UseDefaultCredentials = false;//godaddy
                    smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);
                    string sample = " <div style='background:url(https://istandforthenation.org/Images/certificate.jpg)no-repeat; background-size:100% 100%'><table style='margin:auto!important;'><tr><td></td></tr><tr><td style='padding-top:60%;padding-bottom:60%;'></td><td><br /><br /><br /><br /><h2 style='text-align:center!important'>" + name + "</h2> Has successfully donated to the Indian Army on behalf </ br > of the istandforthenation.org. Thank you Mr/Ms " + name + " for your kind generosity. We would like to inform you that I Stand For The Nation trust is co-ordinated with ARSHA BHARATHI SOCIAL WELFARE SOCIETY to raise NRI Funds across the world. So we thank you again for your donation and assistance JAI HIND. <br /> <p style='text-align:center!important'> " + System.DateTime.Now + " </p></td></tr></table></div>";
                    using (var messages = new MailMessage(GmailUsername, email))
                    {
                        messages.Subject = "I STAND FOR THE NATION";
                        messages.Body = sample;
                        messages.IsBodyHtml = true;
                        smtp.Send(messages);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

        }
    }
}