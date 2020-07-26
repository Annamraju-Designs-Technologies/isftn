using System;
using hrithvika.Models;
using hrithvika.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace hrithvika.Controllers
{
    public class PublicvoiceController : Controller
    {
        ph16787236639_Entities entit = new ph16787236639_Entities();

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public ActionResult Index()
        {
            int active = 1;
            int delete = 0;
            var getdata = entit.publicvoices.Where(x => x.isactive == active && x.isdeleted == delete).OrderByDescending(x => x.createdon).ToList();
            List<Custom_public> list = new List<Custom_public>();
            foreach (var item in getdata)
            {
                Custom_public cp = new Custom_public();
                cp.id = item.id;
                cp.description = item.description;
                cp.NAME = item.NAME;
                cp.phone = item.phone;
                cp.photo = item.photo;
                //cp.video = item.video;
                list.Add(cp);
            }
            return View(list);
        }

        public ActionResult video()
        {
            int active = 1;
            int delete = 0;
            var getdata = entit.publicvoices.Where(x => x.isactive == active && x.isdeleted == delete).OrderByDescending(x => x.createdon).ToList();
            List<Custom_public> list = new List<Custom_public>();
            foreach (var item in getdata)
            {
                Custom_public cp = new Custom_public();
                cp.id = item.id;
                cp.description = item.description;
                cp.NAME = item.NAME;
                cp.phone = item.phone;
                //cp.photo = item.photo;
                cp.video = item.video;
                list.Add(cp);
            }
            return View(list);
        }
        public ActionResult Create(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Custom_public cp, string message, HttpPostedFileBase file, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                if (cp != null)
                {
                    int active = 0;
                    int delete = 0;
                    var allowedExtensions = new[] {
                   ".Jpg", ".png", ".jpg", ".jpeg" ,".JPG",".JPEG","PNG",".pdf",".doc",".docx",".xls",".xlsx",".xlm",".wbk",
                         };

                    Random generator = new Random();
                    string n = generator.Next(0, 999999).ToString("D6");
                   

                        publicvoice pv = new publicvoice();
                        pv.id = Convert.ToInt32(n);
                        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                        pv.createdon = indianTime;
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
                        pv.isactive = active;
                        pv.isdeleted = delete;
                        entit.publicvoices.Add(pv);
                        entit.SaveChanges();
                        return RedirectToAction("Index", "Publicvoice", new { message });
                   
                }
                else
                {
                    message = "* Fields cannot be null";
                    return RedirectToAction("Create", "Publicvoice", new { message });
                }
            }
            else
            {
                return View();
            }
        }

    }
}