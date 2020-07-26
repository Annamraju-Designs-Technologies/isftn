using hrithvika.Entities;
using hrithvika.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClosedXML.Excel;
using PagedList;

namespace hrithvika.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ph16787236639_Entities entit = new ph16787236639_Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListofSubscribers(int? Page_No)
        {
            var GetData = entit.People.OrderByDescending(x => x.Createdon).ToList();
            List<Custom_People> ppl = new List<Custom_People>();

            foreach (var item in GetData)
            {
                Custom_People cp = new Custom_People();
                cp.Name = item.Name;
                cp.Phone = item.Phone;
                cp.Email = item.Email;
                cp.isactive = item.isactive;
                cp.Createdon = item.Createdon;
                cp.State = item.State;
                cp.Country = item.Country;
                ppl.Add(cp);
            }
            int counts = ppl.Count();
            ViewBag.count = counts;
            int Size_Of_Page = 50;
            int No_Of_Page = (Page_No ?? 1);
            return View(ppl.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult ListOFNGOS()
        {
            var GetData = entit.Hrithvik_NGO.OrderByDescending(x => x.createdon).ToList();
            List<customNGO> ppl = new List<customNGO>();
            foreach (var item in GetData)
            {
                customNGO cp = new customNGO();
                cp.id = item.id;
                cp.orgname = item.orgname;
                cp.orgphone = item.orgphone;
                cp.orgemail = item.orgemail;
                cp.orglogo = item.orglogo;
                cp.createdon = item.createdon;
                cp.presidentname = item.presidentname;
                cp.presedentphone = item.presedentphone;
                cp.secretaryname = item.secretaryname;
                cp.secretaryphone = item.secretaryphone;
                ppl.Add(cp);
            }
            return View(ppl);
        }

        public ActionResult EventsList()
        {
            var GetData = entit.HRTVIK_events.OrderByDescending(x => x.Createdon).ToList();
            List<Custom_Events> ppl = new List<Custom_Events>();
            foreach (var item in GetData)
            {
                Custom_Events ce = new Custom_Events();
                ce.id = item.id;
                ce.title = item.title;
                ce.Createdon = item.Createdon;
                ce.description = item.description;
                ce.image_url = item.image_url;
                ppl.Add(ce);
            }
            return View(ppl);
        }

        public ActionResult Create()
        { return View(); }

        public ActionResult AddGallery(int Eventid)
        {
            Custom_GalleryEvents cge = new Custom_GalleryEvents();
            cge.eventid = Eventid;
            return View(cge);
        }

        public ActionResult AddVideoGallery(int Eventid)
        {
            Custom_GalleryEvents cge = new Custom_GalleryEvents();
            cge.eventid = Eventid;
            return View(cge);
        }

        public ActionResult TeamList()
        {
            var getteam = entit.HRTVIK_OurTeam.ToList();
            List<custom_Team> ctlist = new List<custom_Team>();
            foreach (var item in getteam)
            {
                custom_Team ct = new custom_Team();
                ct.id = item.id;
                ct.title = item.title;
                ct.link = item.link;
                ct.type = item.type;
                ct.img_url = item.img_url;
                ct.createdon = item.createdon;
                ctlist.Add(ct);
            }

            return View(ctlist);
        }

        public ActionResult AddTeam(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(entit.Team_type.ToList(), "Id", "Name");
            ViewData["Dbteamtype"] = filetpe;
            return View();
        }

        public ActionResult deleteTeam(int id)
        {
            var employer = entit.HRTVIK_OurTeam.Where(x => x.id == id).SingleOrDefault();
            entit.Entry(employer).State = EntityState.Deleted;
            entit.SaveChanges();
            return RedirectToAction("TeamList");
        }

        public ActionResult deleteImage(int id)
        {
            var image = entit.HRTVIK_OGalery.Where(x => x.id == id).SingleOrDefault();
            entit.Entry(image).State = EntityState.Deleted;
            entit.SaveChanges();
            return RedirectToAction("ListofMainGallery");
        }

        public ActionResult deletevideo(int id)
        {
            var image = entit.HRTVIK_OGalery.Where(x => x.id == id).SingleOrDefault();
            entit.Entry(image).State = EntityState.Deleted;
            entit.SaveChanges();
            return RedirectToAction("Listofvideos");
        }




        public ActionResult AddMainVideo()
        {
            var filetpe = new SelectList(entit.Ogalerytypes.ToList(), "id", "NAME");
            ViewData["Dbtype"] = filetpe;
            return View();

        }

        [HttpPost]
        public ActionResult AddTeam(custom_Team ct, HttpPostedFileBase file, FormCollection Form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HRTVIK_OurTeam ht = new HRTVIK_OurTeam();
                    Random generator = new Random();
                    string r = generator.Next(0, 999999).ToString("D6");
                    ht.id = Convert.ToInt32(r);
                    ht.title = ct.title;
                    ht.createdon = System.DateTime.Now;
                    ht.link = ct.link;
                    if (file != null)
                    {
                        var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG",".PNG"
                         };
                        var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + ht.id + ext; //appending the name with id  
                            var path = "/dynamicPic/" + myfile;
                            ht.img_url = path;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                    var typeid = Form["Type"];
                    int idtype = Convert.ToInt32(typeid);
                    var get_e = entit.Team_type.Where(x => x.id == idtype).SingleOrDefault();
                    ht.type = get_e.NAME;
                    entit.HRTVIK_OurTeam.Add(ht);

                    entit.SaveChanges();
                    return RedirectToAction("TeamList");
                }
                else
                {

                    return RedirectToAction("AddTeam");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public ActionResult AddTeamEdit(int id)
        {
            var filetpe = new SelectList(entit.Team_type.ToList(), "Id", "Name");
            ViewData["Dbteamtype"] = filetpe;
            var getdata = entit.HRTVIK_OurTeam.Where(x => x.id == id).SingleOrDefault();
            custom_Team ct = new custom_Team();
            ct.id = getdata.id;
            ct.title = getdata.title;
            ct.link = getdata.link;
            ct.type = getdata.type;
            ct.img_url = getdata.img_url;
            return View(ct);
        }
        [HttpPost]
        public ActionResult AddTeamEdit(custom_Team ct, HttpPostedFileBase file, FormCollection Form)
        {
            HRTVIK_OurTeam ho = entit.HRTVIK_OurTeam.Where(x => x.id == ct.id).SingleOrDefault();
            ct.title = ho.title;
            ct.link = ho.link;
            if (file != null)
            {
                var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG",".PNG"
                         };
                var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name + "_" + ct.id + ext; //appending the name with id  
                    var path = "/dynamicPic/" + myfile;
                    ct.img_url = path;
                    file.SaveAs(Server.MapPath(path));
                }
            }
            var typeid = Form["Type"];
            int idtype = Convert.ToInt32(typeid);
            var get_e = entit.Team_type.Where(x => x.id == idtype).SingleOrDefault();
            ct.type = get_e.NAME;
            entit.Entry(ct).State = EntityState.Modified;
            entit.SaveChanges();
            return RedirectToAction("TeamList");
        }

        [HttpPost]
        public ActionResult AddVideoGallery(Custom_GalleryEvents cge)
        {
            HRTVIK_gallery htg = new HRTVIK_gallery();
            htg.eventid = cge.eventid;
            htg.image_url = cge.image_url;
            htg.Createdon = System.DateTime.Now;
            htg.eventtype = "Video";
            Random generator = new Random();
            string r = generator.Next(0, 999999).ToString("D6");
            htg.id = Convert.ToInt32(r);
            entit.HRTVIK_gallery.Add(htg);
            entit.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult AddGallery(Custom_GalleryEvents cge, HttpPostedFileBase[] files)
        {
            if (files[0] != null)
            {
                var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG",".PSD",".psd",".PNG"
                         };

                foreach (var item in files)
                {
                    Random generator = new Random();
                    string r = generator.Next(0, 999999).ToString("D6");
                    HRTVIK_gallery p = new HRTVIK_gallery();
                    p.id = Convert.ToInt32(r);
                    p.eventid = cge.eventid;
                    p.Createdon = System.DateTime.Now;
                    p.eventtype = "Image";
                    var fileName = Path.GetFileName(item.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(item.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                        string myfile = name + "_" + p.id + ext; //appending the name with id  
                        var path = "/dynamicPic/" + myfile;
                        p.image_url = path;
                        item.SaveAs(Server.MapPath(path));
                    }
                    entit.HRTVIK_gallery.Add(p);
                    entit.SaveChanges();
                }

            }
            return View();
        }


        public ActionResult ListofMainGallery()
        {
            List<custom_Gallery> lg = new List<custom_Gallery>();
            var gallery = entit.HRTVIK_OGalery.Where(x => x.TYPE == "image").ToList().OrderBy(x => x.rank);
            foreach (var item in gallery)
            {
                custom_Gallery cG = new custom_Gallery();
                cG.path = item.path;
                cG.createdon = item.createdon;
                cG.isimportant = item.isimportant;
                cG.id = item.id;
                cG.rank = item.rank;
                cG.TYPE = item.TYPE;
                lg.Add(cG);
            }
            return View(lg);
        }

        public ActionResult Listofvideos()
        {
            List<custom_Gallery> lg = new List<custom_Gallery>();
            var gallery = entit.HRTVIK_OGalery.Where(x => x.TYPE == "video").ToList().OrderBy(x => x.rank);
            foreach (var item in gallery)
            {
                custom_Gallery cG = new custom_Gallery();
                cG.path = item.path;
                cG.createdon = item.createdon;
                cG.isimportant = item.isimportant;
                cG.id = item.id;
                cG.rank = item.rank;
                cG.TYPE = item.TYPE;
                lg.Add(cG);
            }
            return View(lg);
        }
        public ActionResult AddMainGallery()
        {
            var filetpe = new SelectList(entit.Ogalerytypes.ToList(), "id", "NAME");
            ViewData["Dbtype"] = filetpe;
            return View();
        }
        [HttpPost]
        public ActionResult AddMainGallery(custom_Gallery ga, HttpPostedFileBase[] files, FormCollection Form)
        {
            if (files[0] != null)
            {
                var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG",".PSD",".psd",".PNG"
                         };

                foreach (var item in files)
                {
                    Random generator = new Random();
                    string r = generator.Next(0, 999).ToString("D3");
                    HRTVIK_OGalery p = new HRTVIK_OGalery();
                    p.id = Convert.ToInt32(r);

                    var fileName = Path.GetFileName(item.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(item.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                        string myfile = name + "_" + p.id + ext; //appending the name with id  
                        var path = "/dynamicPic/" + myfile;
                        p.path = path;
                        item.SaveAs(Server.MapPath(path));
                    }
                    p.createdon = System.DateTime.Now;
                    p.TYPE = "image";
                    p.title = ga.title;
                    var typeid = Form["category"];
                    int idtype = Convert.ToInt32(typeid);
                    var get_O = entit.Ogalerytypes.Where(x => x.id == idtype).SingleOrDefault();
                    p.category = get_O.NAME;
                    p.isimportant = ga.isimportant;
                    entit.HRTVIK_OGalery.Add(p);
                    entit.SaveChanges();
                }

            }
            return RedirectToAction("ListofMainGallery", "Admin");
        }

        [HttpPost]
        public ActionResult AddMainVideoGallery(custom_Gallery ga, FormCollection Form)
        {
            Random generator = new Random();
            string r = generator.Next(0, 999999).ToString("D6");
            HRTVIK_OGalery p = new HRTVIK_OGalery();
            p.id = Convert.ToInt32(r);
            p.createdon = System.DateTime.Now;
            p.TYPE = "video";
            var typeid = Form["category"];
            int idtype = Convert.ToInt32(typeid);
            var get_O = entit.Ogalerytypes.Where(x => x.id == idtype).SingleOrDefault();
            p.category = get_O.NAME;
            p.path = ga.path;
            p.isimportant = ga.isimportant;
            entit.HRTVIK_OGalery.Add(p);
            entit.SaveChanges();
            return RedirectToAction("Listofvideos", "Admin");
        }

        public ActionResult editImage(int id)
        {
            var gallery = entit.HRTVIK_OGalery.Where(x => x.id == id).SingleOrDefault();
            custom_Gallery cG = new custom_Gallery();
            cG.id = gallery.id;
            cG.path = gallery.path;
            cG.isimportant = gallery.isimportant;
            return View(cG);
        }

        public ActionResult EditVideos(int id)
        {
            var gallery = entit.HRTVIK_OGalery.Where(x => x.id == id).SingleOrDefault();
            custom_Gallery cG = new custom_Gallery();
            cG.id = gallery.id;
            cG.path = gallery.path;
            cG.isimportant = gallery.isimportant;
            return View(cG);
        }

        [HttpPost]
        public ActionResult editConfirm(custom_Gallery cG)
        {
            HRTVIK_OGalery gallery = entit.HRTVIK_OGalery.Where(x => x.id == cG.id).SingleOrDefault();
            gallery.isimportant = cG.isimportant;
            entit.Entry(gallery).State = EntityState.Modified;
            entit.SaveChanges();
            return RedirectToAction("ListofMainGallery");
        }

        [HttpPost]
        public ActionResult editConfirmVideo(custom_Gallery cG)
        {
            HRTVIK_OGalery gallery = entit.HRTVIK_OGalery.Where(x => x.id == cG.id).SingleOrDefault();
            gallery.isimportant = cG.isimportant;
            entit.Entry(gallery).State = EntityState.Modified;
            entit.SaveChanges();
            return RedirectToAction("Listofvideos");
        }

        [HttpPost]
        public ActionResult Create(Custom_Events ce, HttpPostedFileBase file, FormCollection fobj)
        {
            if (ModelState.IsValid)
            {
                Random generator = new Random();
                string r = generator.Next(0, 999999).ToString("D6");
                var chkdata = entit.HRTVIK_events.Where(x => x.title == ce.title).SingleOrDefault();
                if (chkdata == null)
                {
                    HRTVIK_events p = new HRTVIK_events();
                    p.id = Convert.ToInt32(r);
                    p.title = ce.title;
                    p.description = ce.description;
                    if (file != null)
                    {
                        var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG",".PSD",".psd",".PNG"
                         };
                        var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + p.id + ext; //appending the name with id  
                            var path = "/dynamicPic/" + myfile;
                            p.image_url = path;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                    p.Createdon = System.DateTime.Now;
                    entit.HRTVIK_events.Add(p);
                    entit.SaveChanges();
                    string message = "Thank you for joining with us, we will get back to you shortly";
                    return RedirectToAction("EventsList", "Admin", new { message });
                }
                else
                {
                    Response.Write("<script>alert('Email Id Already exists');</script>");
                    return View();
                }
            }
            else
            {
                string message = "Fields cannot be null";
                return View(new { message }); //change to message by Siva
            }
        }

        [HttpPost]
        public ActionResult ListofMainGallery(int[] Mid)
        {
            int rank = 1;
            foreach (int id in Mid)
            {
                var holidayLocation = entit.HRTVIK_OGalery.Find(id);
                holidayLocation.rank = rank;
                entit.SaveChanges();
                rank += 1;
            }
            return RedirectToAction("ListofMainGallery");
        }
        [HttpPost]
        public ActionResult ListofMainVideos(int[] Mid)
        {
            int rank = 1;
            foreach (int id in Mid)
            {
                var holidayLocation = entit.HRTVIK_OGalery.Find(id);
                holidayLocation.rank = rank;
                entit.SaveChanges();
                rank += 1;
            }
            return RedirectToAction("Listofvideos");
        }
        public ActionResult yuvanirman()
        {
            var getyuva = entit.Hrithvik_yuvanirman.ToList();
            List<custom_yuvanirman> list = new List<custom_yuvanirman>();
            foreach (var item in getyuva)
            {
                custom_yuvanirman cy = new custom_yuvanirman();
                cy.id = item.id;
                cy.about = item.about;
                cy.address = item.address;
                cy.awards = item.awards;
                cy.category = item.category;
                cy.country = item.country;
                cy.state = item.state;
                cy.video1 = item.video1;
                cy.projectimages = item.projectimages;
                cy.projectimages1 = item.projectimages1;
                cy.projectimages2 = item.projectimages2;
                cy.phone = item.phone;
                cy.isactive = item.isactive;
                cy.orglogo = item.orglogo;
                cy.organization = item.organization;
                cy.newsarticle1 = item.newsarticle1;
                cy.lastname = item.lastname;
                cy.firstname = item.firstname;
                cy.email = item.email;
                list.Add(cy);
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Activate(int id)
        {
            if (id != null)
            {
                var active = 1;

                Hrithvik_yuvanirman hy = entit.Hrithvik_yuvanirman.Where(x => x.id == id).SingleOrDefault();
                if (hy != null)
                {
                    hy.isactive = active;
                    entit.Entry(hy).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("Yuvaniman Activate Sucessfully", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Nominations()
        {
            var active = 0;
            int idtype = Convert.ToInt32(active);
            var getyuva = entit.Nominations.Where(x => x.isdeleted == idtype).ToList();
            List<Custom_Nomination> list = new List<Custom_Nomination>();
            foreach (var item in getyuva)
            {
                Custom_Nomination cn = new Custom_Nomination();
                cn.id = item.id;
                cn.title = item.title;
                cn.Description = item.Description;
                cn.video = item.video;
                cn.display_image = item.display_image;
                cn.email = item.email;
                cn.isactive = item.isactive;
                cn.NAME = item.NAME;
                list.Add(cn);
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult NominationActivate(int id)
        {
            if (id != null)
            {
                var active = 1;

                Nomination hy = entit.Nominations.Where(x => x.id == id).SingleOrDefault();
                if (hy != null)
                {
                    hy.isactive = active;
                    entit.Entry(hy).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("Nomination Activate Sucessfully", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult NominationDelete(int id)
        {
            if (id != null)
            {
                var active = 1;

                Nomination hy = entit.Nominations.Where(x => x.id == id).SingleOrDefault();
                if (hy != null)
                {
                    hy.isdeleted = active;
                    entit.Entry(hy).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("Nomination Deleted Sucessfully", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Donationlist()
        {
            var getdata = entit.Donations.Where(x=>x.STATUS== "Success").OrderByDescending(x => x.createdon).ToList();
            List<Custom_Donation> list = new List<Custom_Donation>();
            foreach (var item in getdata)
            {
                Custom_Donation cd = new Custom_Donation();
                cd.id = item.id;
                cd.NAME = item.NAME;
                cd.email = item.email;
                cd.phone = item.phone;
                cd.amount = item.amount;
                cd.createdon = item.createdon;
                cd.STATUS = item.STATUS;
                list.Add(cd);
            }
            return View(list);
        }

        public ActionResult preyava()
        {
            var getdata = entit.Hrithvik_preyuvanirman.OrderByDescending(x => x.createdon).ToList();
            List<Custom_preyuva> list = new List<Custom_preyuva>();
            foreach (var item in getdata)
            {
                Custom_preyuva cd = new Custom_preyuva();
                cd.id = item.id;
                cd.NAME = item.NAME;
                cd.email = item.email;
                cd.phone = item.phone;
                cd.project_title = item.project_title;
                cd.category = item.category;
                cd.createdon = item.createdon;
                list.Add(cd);
            }
            return View(list);
        }

        // export to excel

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        [HttpPost]
        public FileResult Export()
        {

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Name"),
                                            new DataColumn("Email"),
                                            new DataColumn("Phone"),
                                            new DataColumn("State"),
                                            new DataColumn("Country") });

            //var volunteers = from volunteer in entit.People.ToList();
            ////select volunteer;
            var getdata = entit.People.ToList();
            foreach (var item in getdata)
            {
                dt.Rows.Add(item.Name, item.Email, item.Phone, item.State, item.Country);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }

        }

        public ActionResult EditNGOS(int id)
        {
            var filetpe = new SelectList(entit.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            var item = entit.Hrithvik_NGO.Where(x => x.id == id).SingleOrDefault();
            customNGO cp = new customNGO();
            cp.id = item.id;
            cp.orgname = item.orgname;
            cp.orgphone = item.orgphone;
            cp.orgemail = item.orgemail;
            cp.orgaddress = item.orgaddress;
            cp.orglogo = item.orglogo;
            cp.presidentemail = item.presidentemail;
            cp.secretaryemail = item.secretaryemail;
            cp.secretaryname = item.secretaryname;
            cp.secretaryphone = item.secretaryphone;
            cp.createdon = item.createdon;
            cp.presidentname = item.presidentname;
            cp.presedentphone = item.presedentphone;
            cp.secretaryname = item.secretaryname;
            cp.secretaryphone = item.secretaryphone;

            return View(cp);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditNGOS(customNGO cp, HttpPostedFileBase file, HttpPostedFileBase profile, FormCollection Form)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            if (ModelState.IsValid)
            {

                Hrithvik_NGO p = entit.Hrithvik_NGO.Where(x => x.id == cp.id).SingleOrDefault();

                p.id = cp.id;
                p.orgname = cp.orgname;
                p.orgemail = cp.orgemail;
                p.orgphone = cp.orgphone;
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
                var get_O = entit.states.Where(x => x.id == idstate).SingleOrDefault();
                p.State = get_O.NAME;
                p.teamtype = "NGO";
                p.presidentemail = cp.presidentemail;
                p.secretaryemail = cp.secretaryemail;
                entit.Entry(p).State = EntityState.Modified;
                entit.SaveChanges();


                //try
                //{
                //    string txtmessage = "Thank you for filling the information we requested, You are now one among the millions of Indians across the globe who lend their support to our Army";
                //    string strUrl = "http://map-alerts.smsalerts.biz/api/web2sms.php?workingkey=A6c70fec6e274521c7ad710182a16a7ee&to=" + cp.orgphone + "&sender=EDITPT&message=" + txtmessage;
                //    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    Stream s = (Stream)response.GetResponseStream();
                //    StreamReader readStream = new StreamReader(s);
                //    string dataString = readStream.ReadToEnd();
                //    response.Close();
                //    s.Close();
                //    readStream.Close();
                //}
                //catch (Exception)
                //{

                //    return RedirectToAction("NGO", "People", new { message = "Error While Registering!" });
                //}
                string message = "Registered Successfully !";
                return RedirectToAction("ListOFNGOS", "Admin", new { message });
            }
            else
            {
                string message = "* Fields cannot be Empty";
                return RedirectToAction("ListOFNGOS", "Admin", new { message });
            }

        }
        public ActionResult NGoDelete(int id)
        {
            var image = entit.Hrithvik_NGO.Where(x => x.id == id).SingleOrDefault();
            entit.Entry(image).State = EntityState.Deleted;
            entit.SaveChanges();
            return RedirectToAction("ListOFNGOS");
        }
        public ActionResult publicvoice(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            int delete = 0;
            var getdata = entit.publicvoices.Where(x=>x.isdeleted== delete).ToList().OrderByDescending(x => x.createdon);
            List<Custom_public> list = new List<Custom_public>();
            foreach (var item in getdata)
            {
                Custom_public cp = new Custom_public();
                cp.id = item.id;
                cp.description = item.description;
                cp.NAME = item.NAME;
                cp.phone = item.phone;
                cp.photo = item.photo;
                cp.video = item.video;
                cp.isactive = item.isactive;
                list.Add(cp);
            }
            return View(list);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Editpublic(int id)
        {
            int active = 1;
            if (id != null)
            {
                publicvoice pv = entit.publicvoices.Where(x => x.id == id).SingleOrDefault();
                if (pv != null)
                {
                    pv.isactive = active;
                    entit.Entry(pv).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("Editpublic", JsonRequestBehavior.AllowGet);
        }

        public ActionResult publicedit(int id)
        {
            var item = entit.publicvoices.Where(x => x.id == id).SingleOrDefault();
            Custom_public cp = new Custom_public();
            cp.id = item.id;
            cp.description = item.description;
            cp.NAME = item.NAME;
            cp.phone = item.phone;
            cp.photo = item.photo;
            cp.video = item.video;
            return View(cp);
        }
        [HttpPost]
        public ActionResult publicedit(Custom_public cp, string message, HttpPostedFileBase file, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (cp != null)
                {

                    var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG","PNG",".pdf",".doc",".docx",".xls",".xlsx",".xlm",".wbk",
                         };


                    publicvoice pv = entit.publicvoices.Where(x => x.id == cp.id).SingleOrDefault();

                    pv.description = cp.description;
                    pv.phone = cp.phone;
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + pv.id + ext; //appending the name with id  
                                                                      //store the file inside ~/project folder(Img)  
                            var path = "/dynamicPic/" + myfile;
                            pv.photo = path;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                    var allowedExtensionss = new[] {
                                          ".mp4",".mkv",".avi"
                         };
                    if (file1 != null)
                    {
                        var fileName = Path.GetFileName(file1.FileName); //getting only file name(ex-ganesh.jpg)  
                        var ext = Path.GetExtension(file1.FileName); //getting the extension(ex-.jpg)  
                        if (allowedExtensionss.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = name + "_" + pv.id + ext; //appending the name with id  
                                                                      //store the file inside ~/project folder(Img)  
                            var path = "/dynamicPic/" + myfile;
                            pv.video = path;
                            file1.SaveAs(Server.MapPath(path));
                        }
                    }
                    pv.NAME = cp.NAME;
                    entit.Entry(pv).State = EntityState.Modified;
                    entit.SaveChanges();
                    
                    return RedirectToAction("publicvoice", "Admin", new { message="Uploaded Successfully" });

                }
                else
                {
                    message = "* Fields cannot be null";
                    return RedirectToAction("publicedit", "Admin", new { message });
                }
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult deletepublic(int id)
        {
            int active = 1;
            if (id != null)
            {
                publicvoice pv = entit.publicvoices.Where(x => x.id == id).SingleOrDefault();
                if (pv != null)
                {
                    pv.isdeleted = active;
                    entit.Entry(pv).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("deletepublic", JsonRequestBehavior.AllowGet);
        }

        public ActionResult venue()
        {
            var getdata = entit.venues.Where(x => x.isdeletd == 0).ToList();
            List<Custom_venue> list = new List<Custom_venue>();
            foreach (var item in getdata)
            {
                Custom_venue cn = new Custom_venue();
                cn.id = item.id;
                cn.NAME = item.NAME;
                cn.email = item.email;
                cn.phone = item.phone;
                cn.address = item.address;
                cn.createdon = item.createdon;
                cn.venue_area = item.venue_area;
                cn.state = item.state;
                cn.district = item.district;
                list.Add(cn);
            }
            return View(list);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult deletevenue(int id)
        {
            int active = 1;
            if (id != null)
            {
                venue pv = entit.venues.Where(x => x.id == id).SingleOrDefault();
                if (pv != null)
                {
                    pv.isdeletd = active;
                    entit.Entry(pv).State = EntityState.Modified;
                    entit.SaveChanges();
                }
            }
            return Json("deletevenue", JsonRequestBehavior.AllowGet);
        }
    }
}