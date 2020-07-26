using System;
using hrithvika.Entities;
using hrithvika.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstamojoAPI;
using System.IO;
using System.Data.Entity;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace hrithvika.Controllers
{
    public class DonationsController : Controller
    {
        ph16787236639_Entities entit = new ph16787236639_Entities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public ActionResult Index(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            
            var filecountry = new SelectList(entit.countries.ToList(), "id", "NAME");
            ViewData["Dbcountry"] = filecountry;
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Custom_Donation cd, FormCollection Form, string message)
        {

            if (ModelState.IsValid)
            {

                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");
                //var chkdata = entit.Donations.SingleOrDefault();
                Donation d = new Donation();
                d.id = Convert.ToInt32(r);
                Session["donid"] = Convert.ToInt32(r);

                d.NAME = cd.NAME;
                d.email = cd.email;
                d.phone = cd.phone;
                d.amount = cd.amount;
                d.STATUS = "initiated";
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                d.createdon = indianTime;
               
                var countryid = Form["country"];
                int idcountry = Convert.ToInt32(countryid);
                var get_e = entit.countries.Where(x => x.id == idcountry).SingleOrDefault();
                d.country = get_e.NAME;
                entit.Donations.Add(d);
                entit.SaveChanges();
                return RedirectToAction("payments", "Donations", new { did = d.id, amount = d.amount, phone = d.phone, email = d.email, name = d.NAME });
            }



            else
            {
                var filetpe = new SelectList(entit.states.ToList(), "id", "NAME");
                ViewData["Dbstates"] = filetpe;
                var filecountry = new SelectList(entit.countries.ToList(), "id", "NAME");
                ViewData["Dbcountry"] = filecountry;
                return View();
            }

        }

        public ActionResult payments(int did, float amount, string phone, string email, string name)
        {

            payment py = new payment();
            py.id = did;
            py.amount = amount;
            py.NAME = name;
            py.phone = phone;
            py.email = email;
            return View(py);
        }

        [HttpPost]
        public ActionResult payments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult hash(string key, string salt, string txnid, string amount, string pinfo, string email, string mobile, string udf5, StrongNameSignatureInformation fname)
        {
            byte[] hash;
            string d = key + "|" + txnid + "|" + amount + "|" + pinfo + "|" + fname + "|" + email + "|||||" + udf5 + "||||||" + salt;
            var datab = Encoding.UTF8.GetBytes(d);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(datab);
            }
            string json = "{\"success\":\"" + GetStringFromHash(hash) + "\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
            return Json(json);
        }

        private string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2").ToLower());
            }
            return result.ToString();
        }

        public ActionResult Failure()
        {
            return View();
        }


        public ActionResult Create(string Id)
        {
            string donid = Session["donid"].ToString();
            int dnid = Convert.ToInt32(donid);
            Donation d = entit.Donations.Where(x => x.id == dnid).SingleOrDefault();
            d.STATUS = "Success";
            entit.Entry(d).State = EntityState.Modified;
            entit.SaveChanges();
            try
            {
                string Password = "Bharadwaj123@!";
                string Msg = " Thank you for your support and guidance to the Our Brave Heart's,Donation ID :" + Id + ", Amount :" + d.amount;
                string OPTINS = "ISFNDS";
                string MobileNumber = d.phone;
                string type = "203";
                string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ixtouch&password=" + Password + "&message=" + Msg + "&sender=" + OPTINS + "&mobile=" + MobileNumber + "&type=" + type;
                WebRequest request = WebRequest.Create(strUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
                response.Close();
                s.Close();
                readStream.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
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

                string sample = " <div style='background:url(https://istandforthenation.org/Images/certificate.jpg)no-repeat; background-size:100% 100%'><table style='margin:auto!important;'><tr><td></td></tr><tr><td style='padding-top:60%;padding-bottom:60%;'></td><td><br /><br /><br /><br /><h2 style='text-align:center!important'>" + d.NAME + "</h2>Has successfully donated Rs. " + d.amount + " to the Indian Army on behalf </ br > of the istandforthenation.org we thank you for your donation and assistance<br /> <p style='text-align:center!important'> " + d.createdon + " </p></td></tr></table></div>";


                using (var messages = new MailMessage(GmailUsername, d.email))
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
            string message = "Donated Successfully !";
            return RedirectToAction("Index", "Home", new { message });



        }
        public ActionResult paymentFailure()
        {
            return View();
        }
        //public ActionResult redirecttopaymentgateway(string Name, string Email, string Phone, double Amount,int donid)
        //{
        //    string Insta_client_id = "pzL4QJOqovNgn1M7macD4p3aliWuDvJ5kocJjGVW",
        //     Insta_client_secret = "wdVlfPLKfvIIoEH4yITGOaXdi3RAtnJwPnp8U7iiTqQdY4UoAb3iJxFHfol5j9wEGSBAR9bRkFcudNxe8iy0IjUy1KcJjozLfxlR7wUCDrwwUWIMo1eayriGVyB5tp9z",
        //     Insta_Auth_Endpoint = "https://www.instamojo.com/oauth2/token/",
        //     Insta_Endpoint = "https://api.instamojo.com/v2/";

        //    //string Insta_client_id = "test_N3wo920HRipiiUx65r0maCnXSeJVDmTuCro",
        //    //            Insta_client_secret = "test_351FYWeHzw4rzUQsb2vDFhONcFCnnoBFYcN5Brz4YeeqV5utVoSdUuWK3KxiLr0zO7LVbYHAxzmsxJWqqBT4tGPM0CgP36cHYuvx8FYEXWFaGdVvfQOEc7RRgaV",
        //    //            Insta_Auth_Endpoint = "https://test.instamojo.com/oauth2/token/",
        //    //            Insta_Endpoint = "https://test.instamojo.com/v2/";
        //    Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);
        //    PaymentOrder objPaymentRequest = new PaymentOrder();
        //    objPaymentRequest.name = Name;
        //    objPaymentRequest.email = Email;
        //    objPaymentRequest.phone = Phone;
        //    objPaymentRequest.description = "Donation to ISTANDFORTHENATION";
        //    objPaymentRequest.amount = Amount;
        //    string randomName = Path.GetRandomFileName();
        //    randomName = randomName.Replace(".", string.Empty);
        //    objPaymentRequest.transaction_id = randomName;
        //    objPaymentRequest.redirect_url = "https://istandforthenation.org/Donations/PaymentSuccess?email=" + Email + "&price=" + Amount + "&phone=" + Phone + "&donid=" + donid + "";
        //    //objPaymentRequest.webhook_url = "https://istandforthenation.org/webhook";
        //    CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
        //    Response.Redirect(objPaymentResponse.payment_options.payment_url);
        //    //MessageBox.Show("Payment URL = " + objPaymentResponse.payment_options.payment_url);
        //    return null;
        //}

        //public ActionResult PaymentSuccess()
        //{
        //    string email = Request.QueryString["email"].ToString();
        //    string getid = Request.QueryString["donid"].ToString();
        //    string phone = Request.QueryString["phone"].ToString();
        //    string price = Request.QueryString["price"].ToString();
        //    string status = Request.QueryString["payment_status"].ToString();
        //    string transaction_id = Request.QueryString["transaction_id"].ToString();
        //    int id = Convert.ToInt32(getid);
        //    if (status == "Credit")
        //    {
        //        Donation ds = entit.Donations.Where(x => x.id == id).SingleOrDefault();
        //        ds.STATUS = status;

        //        entit.Entry(ds).State = EntityState.Modified;
        //        entit.SaveChanges();
        //        try
        //        {
        //            string Password = "Bharadwaj123@!";
        //            string Msg = " Thank you for your support and guidance to the Our Brave Heart's,Donation ID :" + transaction_id + ", Amount :" + ds.amount;
        //            string OPTINS = "ISFNDS";
        //            string MobileNumber = phone;
        //            string type = "203";
        //            string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ixtouch&password=" + Password + "&message=" + Msg + "&sender=" + OPTINS + "&mobile=" + MobileNumber + "&type=" + type;
        //            System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
        //            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //            Stream s = (Stream)response.GetResponseStream();
        //            StreamReader readStream = new StreamReader(s);
        //            string dataString = readStream.ReadToEnd();
        //            response.Close();
        //            s.Close();
        //            readStream.Close();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        try
        //        {
        //            string GmailUsername = "thankyou@istandforthenation.org";
        //            string GmailPassword = "mGQ=5eRh";
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = "relay-hosting.secureserver.net"; //godaddy
        //                                                          //smtp.Host = "smtp.gmail.com"; //localhost
        //            smtp.Port = 25;
        //            //smtp.EnableSsl = true; //localhost
        //            smtp.EnableSsl = false;//godaddy
        //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            //smtp.UseDefaultCredentials = true;//localhost
        //            smtp.UseDefaultCredentials = false;//godaddy
        //            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

        //            string sample = " <div style='background:url(https://istandforthenation.org/Images/certificate.jpg)no-repeat; background-size:100% 100%'><table style='margin:auto!important;'><tr><td></td></tr><tr><td style='padding-top:60%;padding-bottom:60%;'></td><td><br /><br /><br /><br /><h2 style='text-align:center!important'>" + ds.NAME + "</h2>Has successfully donated Rs. " + ds.amount + " to the Indian Army on behalf </ br > of the istandforthenation.org we thank you for your donation and assistance<br /> <p style='text-align:center!important'> " + ds.createdon + " </p></td></tr></table></div>";


        //            using (var messages = new MailMessage(GmailUsername, email))
        //            {
        //                messages.Subject = "I STAND FOR THE NATION";
        //                messages.Body = sample;
        //                messages.IsBodyHtml = true;
        //                smtp.Send(messages);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        string success = "Donated Successfully !";
        //        return RedirectToAction("Index", "Home", new { message = success });
        //    }
        //    else
        //    {
        //        Donation ds = entit.Donations.Where(x => x.id == id).FirstOrDefault();
        //        ds.STATUS = status;
        //        entit.Entry(ds).State = EntityState.Modified;
        //        entit.SaveChanges();
        //        string success = "Donation Failed !";
        //        return RedirectToAction("Index", "Home", new { message = success });

        //    }

        //}
        
    }
}

