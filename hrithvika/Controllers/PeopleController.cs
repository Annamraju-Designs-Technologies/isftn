using CaptchaMvc.HtmlHelpers;
using hrithvika.Entities;
using hrithvika.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hrithvika.Controllers
{
    public class PeopleController : Controller
    {
        ph16787236639_Entities sn = new ph16787236639_Entities();
        public ActionResult Index(string message)
        {
            return View();
        }


        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public ActionResult Create(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(sn.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            var filecountry = new SelectList(sn.countries.ToList(), "id", "NAME");
            ViewData["Dbcountry"] = filecountry;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Custom_People cp, FormCollection Form)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            if (ModelState.IsValid)
            {
                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");
                var chkdata = sn.People.Where(x => x.Phone == cp.Phone).SingleOrDefault();
                if (chkdata == null)
                {
                    Person p = new Person();
                    p.Id = Convert.ToInt32(r);
                    p.Name = cp.Name;
                    p.Email = cp.Email;
                    p.Phone = cp.Phone;
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    p.Createdon = indianTime;
                    p.isdeleted = false;
                    p.isactive = cp.isactive;
                    var statesid = Form["state"];
                    int idstate = Convert.ToInt32(statesid);
                    var get_O = sn.states.Where(x => x.id == idstate).SingleOrDefault();
                    p.State = get_O.NAME;
                    var countryid = Form["country"];
                    int idcountry = Convert.ToInt32(countryid);
                    var get_e = sn.countries.Where(x => x.id == idcountry).SingleOrDefault();
                    p.Country = get_e.NAME;
                    sn.People.Add(p);
                    sn.SaveChanges();
                    string message = "Registered Successfully !";
                    try
                    {
                        string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                        string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + cp.Phone + "&sender=EDITPT&message=" + txtmessage;
                        System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream s = (Stream)response.GetResponseStream();
                        StreamReader readStream = new StreamReader(s);
                        string dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Create", "People", new { message });
                    }
                    return RedirectToAction("Create", "People", new { message });
                }
                else
                {
                    Response.Write("<script>alert('Phone number already exists');</script>");
                    return RedirectToAction("Create", "People");
                }
            }
            else
            {
                string message = "* Fields cannot be null";
                return RedirectToAction("Create", "People", new { message });
            }
            //}
            //else
            //{
            //    ViewBag.ErrMessage = "Error: captcha is not valid.";
            //    return View();

            //}
        }
        public ActionResult NGO(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(sn.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult NGO(customNGO cp, HttpPostedFileBase file, HttpPostedFileBase profile, FormCollection Form)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            if (ModelState.IsValid)
            {
                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");
                var chkdata = sn.Hrithvik_NGO.Where(x => x.orgemail == cp.orgemail).SingleOrDefault();
                if (chkdata == null)
                {
                    Hrithvik_NGO p = new Hrithvik_NGO();
                    p.id = Convert.ToInt32(r);
                    p.orgname = cp.orgname;
                    p.orgemail = cp.orgemail;
                    p.orgphone = cp.orgphone;
                    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    p.createdon = indianTime;
                    p.orgaddress = cp.orgaddress;
                    p.presedentphone = cp.presedentphone;
                    p.presidentname = cp.presidentname;
                    p.secretaryname = cp.secretaryname;
                    p.secretaryphone = cp.secretaryphone;
                    var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG","PNG",".pdf",".doc",".docx",".xls",".xlsx",".xlm",".wbk"
                         };
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + p.id + ext; //appending the name with id  
                                                                     //store the file inside ~/project folder(Img)  
                            var path = "/dynamicPic/" + myfile;
                            p.orglogo = path;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                    if (profile != null)
                    {
                        var fileName = Path.GetFileName(profile.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(profile.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + p.id + ext; //appending the name with id  
                                                                     //store the file inside ~/project folder(Img)  
                            var path = "/dynamicPic/" + myfile;
                            p.orgdocuments = path;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                    var statesid = Form["state"];
                    int idstate = Convert.ToInt32(statesid);
                    var get_O = sn.states.Where(x => x.id == idstate).SingleOrDefault();
                    p.State = get_O.NAME;
                    p.teamtype = "NGO";
                    p.presidentemail = cp.presidentemail;
                    p.secretaryemail = cp.secretaryemail;
                    sn.Hrithvik_NGO.Add(p);
                    sn.SaveChanges();
                    HRTVIK_OurTeam ho = new HRTVIK_OurTeam();
                    ho.id = Convert.ToInt32(r);
                    ho.img_url = p.orglogo;
                    ho.type = p.teamtype;
                    ho.link = "https://istandforthenation.org/";
                    ho.createdon = System.DateTime.Now;
                    ho.title = p.orgname;
                    sn.HRTVIK_OurTeam.Add(ho);
                    sn.SaveChanges();
                }
                else
                {
                    Response.Write("<script>alert('Email already exists');</script>");
                    return View();
                }
                try
                {
                    string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                    string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + cp.orgphone + "&sender=EDITPT&message=" + txtmessage;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                }
                catch (Exception)
                {

                    return RedirectToAction("NGO", "People", new { message = "Error While Registering!" });
                }
                string message = "Registered Successfully !";
                return RedirectToAction("NGO", "People", new { message });
            }
            else
            {
               
                var filetpe = new SelectList(sn.states.ToList(), "id", "NAME");
                ViewData["Dbstates"] = filetpe;
                return View();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateJson(FormCollection fobj)
        {
            var phonemuber = fobj["phone"].ToString();
            Random generator = new Random();
            string r = generator.Next(0, 999999).ToString("D6");
            var chkdata = sn.People.Where(x => x.Phone == phonemuber).SingleOrDefault();
            if (chkdata == null)
            {
                Person p = new Person();
                p.Id = Convert.ToInt32(r);
                p.Name = fobj["name"];
                p.Email = fobj["email"];
                p.Phone = fobj["phone"];
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                p.Createdon = indianTime;
                p.isdeleted = false;
                p.isactive = false;
                p.State = fobj["state"];
                p.Country = fobj["country"];
                sn.People.Add(p);
                sn.SaveChanges();
                try
                {
                    string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                    string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + p.Phone + "&sender=EDITPT&message=" + txtmessage;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
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
                    return RedirectToAction("Events", "Home", new { message = "error while sending message" });
                }
                string status = "Congratulations , you are part of the team from now";
                return RedirectToAction("Events", "Home", new { message = status });
            }
            else
            {

                string status = "Phone number already exists";
                return RedirectToAction("Events", "Home", new { message = status });
            }


        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult CreateJsonTeam(FormCollection fobj)
        {
            var phonemuber = fobj["phone"].ToString();
            Random generator = new Random();
            string r = generator.Next(0, 999999).ToString("D6");
            var chkdata = sn.People.Where(x => x.Phone == phonemuber).SingleOrDefault();
            if (chkdata == null)
            {
                Person p = new Person();
                p.Id = Convert.ToInt32(r);
                p.Name = fobj["name"];
                p.Email = fobj["email"];
                p.Phone = fobj["phone"];
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                p.Createdon = indianTime;
                p.isdeleted = false;
                p.isactive = false;
                p.State = fobj["state"];
                p.Country = fobj["country"];
                sn.People.Add(p);
                sn.SaveChanges();
                try
                {
                    string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                    string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + p.Phone + "&sender=EDITPT&message=" + txtmessage;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
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
                    return RedirectToAction("GetTeam", "Home", new { message = "error while sending message" });
                }
                string status = "Congratulations , you are part of the team from now";
                return RedirectToAction("GetTeam", "Home", new { message = status });
            }
            else
            {

                string status = "Phone number already exists";
                return RedirectToAction("GetTeam", "Home", new { message = status });
            }


        }

        public ActionResult Createhome(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(sn.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            var filecountry = new SelectList(sn.countries.ToList(), "id", "NAME");
            ViewData["Dbcountry"] = filecountry;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Createhome(FormCollection fobj)
        {
            var phonemuber = fobj["phone"].ToString();
            Random generator = new Random();
            string r = generator.Next(0, 999999).ToString("D6");
            var chkdata = sn.People.Where(x => x.Phone == phonemuber).SingleOrDefault();
            if (chkdata == null)
            {
                Person p = new Person();
                p.Id = Convert.ToInt32(r);
                p.Name = fobj["name"];
                p.Email = fobj["email"];
                p.Phone = fobj["phone"];
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                p.Createdon = indianTime;
                p.isdeleted = false;
                p.isactive = false;
                p.State = fobj["state"];
                p.Country = fobj["country"];
                sn.People.Add(p);
                sn.SaveChanges();
                try
                {
                    string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                    string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + p.Phone + "&sender=EDITPT&message=" + txtmessage;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
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
                    return RedirectToAction("Index", "Home", new { message = "error while sending message" });
                }
                string status = "Congratulations , you are part of the team from now";
                return RedirectToAction("Index", "Home", new { message = status });
            }
            else
            {

                string status = "Phone number already exists";
                return RedirectToAction("Index", "Home", new { message = status });
            }


        }

        public ActionResult Create_yuvanirman(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(sn.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            var filecategory = new SelectList(sn.categories.ToList(), "id", "NAME");
            ViewData["Dbcategory"] = filecategory;
            var filecountry = new SelectList(sn.countries.ToList(), "id", "NAME");
            ViewData["Dbcountry"] = filecountry;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create_yuvanirman(custom_yuvanirman cy, string message, HttpPostedFileBase file, HttpPostedFileBase file5, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, FormCollection Form)
        {
            if (ModelState.IsValid)
            {
                if (cy != null)
                {
                    if (file != null)
                    {
                        var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG","PNG",".pdf",".doc",".docx",".xls",".xlsx",".xlm",".wbk"
                         };
                        Random generator = new Random();
                        string y = generator.Next(0, 999999).ToString("D6");
                        var getyuva = sn.Hrithvik_yuvanirman.Where(x => x.phone == cy.phone).SingleOrDefault();
                        if (getyuva == null)
                        {
                            var active = 0;
                            Hrithvik_yuvanirman hy = new Hrithvik_yuvanirman();
                            hy.id = Convert.ToInt32(y);
                            hy.about = cy.about;
                            hy.address = cy.address;
                            hy.awards = cy.awards;
                            if (file5 != null)
                            {
                                var fileName = Path.GetFileName(file5.FileName); //getting only file name(ex-ganesh.jpg)  
                                var ext = Path.GetExtension(file5.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(ext)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + ext; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.awards = path;
                                    file5.SaveAs(Server.MapPath(path));
                                }

                                var categoeyid = Form["category"];
                                int idcategory = Convert.ToInt32(categoeyid);
                                var get_c = sn.categories.Where(x => x.id == idcategory).SingleOrDefault();
                                hy.category = get_c.NAME;
                                var countryid = Form["country"];
                                int idcountry = Convert.ToInt32(countryid);
                                var get_e = sn.countries.Where(x => x.id == idcountry).SingleOrDefault();
                                hy.country = get_e.NAME;
                                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                                hy.createdon = indianTime;
                                hy.email = cy.email;
                                hy.firstname = cy.firstname;
                                hy.isactive = Convert.ToInt32(active);
                                hy.lastname = cy.lastname;

                                var filelogo = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                                var extlogo = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(extlogo)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(filelogo); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + extlogo; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.orglogo = path;
                                    file.SaveAs(Server.MapPath(path));
                                }
                            }


                            hy.organization = cy.organization;
                            hy.phone = cy.phone;
                            if (file4 != null)
                            {
                                var fileName = Path.GetFileName(file4.FileName); //getting only file name(ex-ganesh.jpg)  
                                var ext = Path.GetExtension(file4.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(ext)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + ext; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.newsarticle1 = path;
                                    file4.SaveAs(Server.MapPath(path));
                                }
                            }

                            if (file1 != null)
                            {
                                var fileName = Path.GetFileName(file1.FileName); //getting only file name(ex-ganesh.jpg)  
                                var ext = Path.GetExtension(file1.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(ext)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + ext; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.projectimages = path;
                                    file1.SaveAs(Server.MapPath(path));
                                }
                            }
                            if (file2 != null)
                            {
                                var fileName = Path.GetFileName(file2.FileName); //getting only file name(ex-ganesh.jpg)  
                                var ext = Path.GetExtension(file2.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(ext)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + ext; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.projectimages1 = path;
                                    file2.SaveAs(Server.MapPath(path));
                                }
                            }
                            if (file3 != null)
                            {
                                var fileName = Path.GetFileName(file3.FileName); //getting only file name(ex-ganesh.jpg)  
                                var ext = Path.GetExtension(file3.FileName); //getting the extension(ex-.jpg)  
                                if (allowedExtensions.Contains(ext)) //check what type of extension  
                                {
                                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                    string myfile = name + "_" + hy.id + ext; //appending the name with id  
                                                                              //store the file inside ~/project folder(Img)  
                                    var path = "/dynamicPic/" + myfile;
                                    hy.projectimages2 = path;
                                    file3.SaveAs(Server.MapPath(path));
                                }
                            }
                            var statesid = Form["state"];
                            int idstate = Convert.ToInt32(statesid);
                            var get_O = sn.states.Where(x => x.id == idstate).SingleOrDefault();
                            hy.state = get_O.NAME;
                            hy.video1 = cy.video1;
                            sn.Hrithvik_yuvanirman.Add(hy);
                            sn.SaveChanges();
                            message = "Uploaded Successfully";
                            return RedirectToAction("Index", "KalamYuvanirman", new { message });
                        }
                        else
                        {
                            message = "Phone Number is Already Exist";
                            return RedirectToAction("Create_yuvanirman", "People", new { message });
                        }

                    }
                    else
                    {
                        message = "* Diplay Image cannot be null";
                        return RedirectToAction("Create_yuvanirman", "People", new { message });
                    }
                }
                else
                {
                    message = "* Fields cannot be null";
                    return RedirectToAction("Create_yuvanirman", "People", new { message });
                }
            }

            else
            {
                return RedirectToAction("Create_yuvanirman", "People", new { message });
            }

        }


        [AllowAnonymous]
        public ActionResult yuvanirman()
        {
            return View();
        }
        public ActionResult Create_Nominations(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(sn.Nomination_type.ToList(), "id", "NAME");
            ViewData["Dbtype"] = filetpe;
            return View();
        }
        [HttpPost]
        public ActionResult Create_Nominations(Custom_Nomination cn, string message, HttpPostedFileBase file, FormCollection Form)
        {
            if (ModelState.IsValid)
            {
                if (cn != null)
                {
                    var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG","PNG",".pdf",".doc",".docx",".xls",".xlsx",".xlm",".wbk"
                         };
                    Random generator = new Random();
                    string n = generator.Next(0, 999999).ToString("D6");
                    var getnomi = sn.Nominations.Where(x => x.phone == cn.phone).SingleOrDefault();
                    if (getnomi == null)
                    {
                        var active = 0;
                        var delete = 0;
                        Nomination nm = new Nomination();
                        nm.id = Convert.ToInt32(n);
                        nm.isactive = Convert.ToInt32(active);
                        nm.isactive = Convert.ToInt32(delete);
                        if (file != null)
                        {
                            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                string myfile = name + "_" + nm.id + ext; //appending the name with id  
                                                                          //store the file inside ~/project folder(Img)  
                                var path = "/dynamicPic/" + myfile;
                                nm.display_image = path;
                                file.SaveAs(Server.MapPath(path));
                            }
                        }
                        nm.Description = cn.Description;
                        nm.email = cn.email;
                        nm.phone = cn.phone;
                        nm.NAME = cn.NAME;
                        var typeid = Form["Type"];
                        int idtype = Convert.ToInt32(typeid);
                        var get_e = sn.Nomination_type.Where(x => x.id == idtype).SingleOrDefault();
                        nm.category = get_e.NAME;
                        nm.title = cn.title;
                        nm.video = cn.video;
                        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                        nm.createdon = indianTime;
                        sn.Nominations.Add(nm);
                        sn.SaveChanges();
                        return RedirectToAction("Index", "Nominations", new { message });
                    }
                    else
                    {
                        message = "Phone Number is Already Exist";
                        return RedirectToAction("Create_yuvanirman", "People", new { message });
                    }
                }
                else
                {
                    message = "* Fields cannot be null";
                    return RedirectToAction("Create_Nominations", "People", new { message });
                }
            }
            else
            {
                return View();
            }
        }
    }
}