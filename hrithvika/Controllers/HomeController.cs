using hrithvika.Entities;
using hrithvika.Models;
using InstamojoAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hrithvika.Controllers
{

    public class HomeController : Controller
    {
        ph16787236639_Entities entit = new ph16787236639_Entities();
        public ActionResult Index(string message)
        {
            if (message != null)
            {
                ViewBag.message = message;
            }
            var getevents = entit.HRTVIK_OGalery.Where(x => x.isimportant == true).ToList().OrderBy(x => x.rank);
            List<custom_Gallery> celist = new List<custom_Gallery>();
            foreach (var item in getevents)
            {
                custom_Gallery ce = new custom_Gallery();
                ce.id = item.id;
                ce.path = item.path;
                ce.createdon = item.createdon;
                ce.isimportant = item.isimportant;
                ce.TYPE = item.TYPE;

                celist.Add(ce);
            }
            return View(celist);

        }
        public ActionResult Landingpage() {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetTeam(string message)
        {
            if (message != null)
            {
                ViewBag.message = message;
            }
            var getevents = entit.HRTVIK_OurTeam.OrderByDescending(x => x.createdon).ToList();
            List<custom_Team> celist = new List<custom_Team>();
            foreach (var item in getevents)
            {
                custom_Team ce = new custom_Team();
                ce.id = item.id;
                ce.img_url = item.img_url;
                ce.title = item.title;
                ce.createdon = item.createdon;
                ce.link = item.link;
                celist.Add(ce);

            }
            return View(celist);
        }
        public ActionResult GetTeamType(string message, string type)
        {
            if (message != null)
            {
                ViewBag.message = message;
            }
            var getevents = entit.HRTVIK_OurTeam.Where(x => x.type == type).OrderByDescending(x => x.createdon).ToList();
            List<custom_Team> celist = new List<custom_Team>();
            foreach (var item in getevents)
            {
                custom_Team ce = new custom_Team();
                ce.id = item.id;
                ce.img_url = item.img_url;
                ce.title = item.title;
                ce.createdon = item.createdon;
                ce.link = item.link;
                celist.Add(ce);

            }
            return View(celist);
        }

        public ActionResult Events(string message)
        {
            if (message != null)
            {
                ViewBag.message = message;
            }
            var getevents = entit.HRTVIK_events.OrderByDescending(x=>x.Createdon).ToList();
            List<Custom_Events> celist = new List<Custom_Events>();
            foreach (var item in getevents)
            {
                Custom_Events ce = new Custom_Events();
                ce.id = item.id;
                ce.image_url = item.image_url;
                ce.title = item.title;
                ce.description = item.description;
                celist.Add(ce);
            }
            return View(celist);
        }
        public ActionResult EventDetails(int eventID)
        {
            var Getparent = entit.HRTVIK_events.Where(x => x.id == eventID).SingleOrDefault();
            ViewBag.EventTile = Getparent.title;
            var getevents = entit.HRTVIK_gallery.Where(x => x.eventtype == "Image" && x.eventid == eventID).OrderByDescending(x=>x.Createdon).ToList();
            List<Custom_GalleryEvents> celist = new List<Custom_GalleryEvents>();
            foreach (var item in getevents)
            {
                Custom_GalleryEvents ce = new Custom_GalleryEvents();
                ce.id = item.id;
                ce.eventid = item.eventid;
                ce.image_url = item.image_url;
                ce.eventtype = item.eventtype;
                ViewBag.eventid = item.eventid;
                celist.Add(ce);
            }
            return View(celist);
        }

        public ActionResult gallery()
        {
            string image = "image";
            string type = "Support";
            var getevents = entit.HRTVIK_OGalery.Where(x => x.TYPE == image && x.category == type).OrderBy(x => x.rank).ToList();
            List<custom_Gallery> celist = new List<custom_Gallery>();
            foreach (var item in getevents)
            {
                custom_Gallery ce = new custom_Gallery();
                ce.id = item.id;
                ce.path = item.path;
                ce.title = item.title;

                celist.Add(ce);
            }
            return View(celist);
        }
        public ActionResult gallerytype(string type)
        {
            string image = "image";
            var getevents = entit.HRTVIK_OGalery.Where(x => x.TYPE == image && x.category == type).OrderBy(x => x.rank).ToList();
            List<custom_Gallery> celist = new List<custom_Gallery>();
            foreach (var item in getevents)
            {
                custom_Gallery ce = new custom_Gallery();
                ce.id = item.id;
                ce.path = item.path;
                ce.title = item.title;

                celist.Add(ce);
            }
            return View(celist);
        }
        public ActionResult galleryvideo()
        {
            string video = "Video";
            var getevents = entit.HRTVIK_OGalery.Where(x => x.TYPE == video).OrderBy(x => x.rank).ToList();
            List<custom_Gallery> celist = new List<custom_Gallery>();
            foreach (var item in getevents)
            {
                custom_Gallery ce = new custom_Gallery();
                ce.id = item.id;
                ce.path = item.path;

                celist.Add(ce);
            }
            return View(celist);
        }
        public ActionResult galleryvideotype(string vtype)
        {
            string video = "Video";
            var getevents = entit.HRTVIK_OGalery.Where(x => x.TYPE == video && x.category == vtype).OrderBy(x => x.rank).ToList();
            List<custom_Gallery> celist = new List<custom_Gallery>();
            foreach (var item in getevents)
            {
                custom_Gallery ce = new custom_Gallery();
                ce.id = item.id;
                ce.path = item.path;

                celist.Add(ce);
            }
            return View(celist);
        }

        public ActionResult EventVideos(int eventID)
        {
            var Getparent = entit.HRTVIK_events.Where(x => x.id == eventID).SingleOrDefault();
            ViewBag.EventTile = Getparent.title;
            var getevents = entit.HRTVIK_gallery.Where(x => x.eventtype != "Image" && x.eventid == eventID).ToList();
            List<Custom_GalleryEvents> celist = new List<Custom_GalleryEvents>();
            foreach (var item in getevents)
            {
                Custom_GalleryEvents ce = new Custom_GalleryEvents();
                ce.id = item.id;
                ce.eventid = item.eventid;
                ce.image_url = item.image_url;
                ce.eventtype = item.eventtype;
                celist.Add(ce);
            }
            ViewBag.eventid = eventID;
            return View(celist);
        }

        public ActionResult organizers()
        {
            return View();
        }

        public ActionResult Kalamyuvanirman()
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
        public ActionResult yuvanirmanDetails(int eventID)
        {

            var getyuva = entit.Hrithvik_yuvanirman.Where(x => x.id == eventID).SingleOrDefault();
            custom_yuvanirman cy = new custom_yuvanirman();
            cy.id = getyuva.id;
            cy.about = getyuva.about;
            cy.address = getyuva.address;
            cy.awards = getyuva.awards;
            cy.category = getyuva.category;
            cy.country = getyuva.country;
            cy.state = getyuva.state;
            cy.video1 = getyuva.video1;
            cy.projectimages = getyuva.projectimages;
            cy.projectimages1 = getyuva.projectimages1;
            cy.projectimages2 = getyuva.projectimages2;
            cy.phone = getyuva.phone;
            cy.orglogo = getyuva.orglogo;
            cy.organization = getyuva.organization;
            cy.newsarticle1 = getyuva.newsarticle1;
            cy.lastname = getyuva.lastname;
            cy.firstname = getyuva.firstname;
            cy.email = getyuva.email;
            return View(cy);
        }

        public ActionResult Nominations()
        {
            return View();
        }

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public ActionResult NationalAnthem() {

            return View();

        }

    }
}