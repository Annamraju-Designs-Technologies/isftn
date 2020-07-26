using System;
using hrithvika.Models;
using hrithvika.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hrithvika.Controllers
{
    public class KalamYuvanirmanController : Controller
    {
        // GET: KalamYuvanirman
        ph16787236639_Entities entit = new ph16787236639_Entities();
        public ActionResult Index()
        {
            var getyuva = entit.Hrithvik_yuvanirman.Where(x => x.isactive == 1).ToList();
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

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public ActionResult Create(string message)
        {
            if (message != null)
            {
                ViewBag.success = message;
            }
            var filetpe = new SelectList(entit.Nomination_type.ToList(), "id", "NAME");
            ViewData["Dbtype"] = filetpe;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Custom_preyuva cp, string message, FormCollection Form)
        {
            if (ModelState.IsValid)
            {
                if (cp != null)
                {
                  
                    Random generator = new Random();
                    string n = generator.Next(0, 999999).ToString("D6");
                    var getnomi = entit.Nominations.Where(x => x.phone == cp.phone).SingleOrDefault();
                    if (getnomi == null)
                    {
                       
                        Hrithvik_preyuvanirman hp = new Hrithvik_preyuvanirman();
                        hp.id = Convert.ToInt32(n);
                       DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                        hp.createdon = indianTime;
                        hp.Address = cp.Address;
                        var typeid = Form["Type"];
                        int idtype = Convert.ToInt32(typeid);
                        var get_e = entit.Nomination_type.Where(x => x.id == idtype).SingleOrDefault();
                        hp.category = get_e.NAME;
                        hp.class_or_course = cp.class_or_course;
                        hp.Date_of_birth = cp.Date_of_birth;
                        hp.email = cp.email;
                        hp.Father_name = cp.Father_name;
                        hp.group_mumbers = cp.group_mumbers;
                        hp.institution_address = cp.institution_address;
                        hp.institution_name = cp.institution_name;
                        hp.NAME = cp.NAME;
                        hp.phone = cp.phone;
                        hp.project_description = cp.project_description;
                        hp.project_title = cp.project_title;
                        entit.Hrithvik_preyuvanirman.Add(hp);
                        entit.SaveChanges();
                        return RedirectToAction("Index", "KalamYuvanirman", new { message });
                    }
                    else
                    {
                        message = "Phone Number is Already Exist";
                        return RedirectToAction("Create", "KalamYuvanirman", new { message });
                    }
                }
                else
                {
                    message = "* Fields cannot be null";
                    return RedirectToAction("Create", "KalamYuvanirman", new { message });
                }
            }
            else
            {
                return View();
            }
        }

    }
}