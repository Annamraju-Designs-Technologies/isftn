using hrithvika.Entities;
using hrithvika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hrithvika.Controllers
{
    public class VenueController : Controller
    {
        ph16787236639_Entities entit = new ph16787236639_Entities();
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var getdatas = entit.venues.Where(x => x.isdeletd == 0 && x.venue_area.Contains(search) || x.address.Contains(search)).OrderByDescending(x => x.createdon).ToList();
                List<Custom_venue> lists = new List<Custom_venue>();
                foreach (var item in getdatas)
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
                    cn.fblink = item.fblink;
                    cn.district = item.district;
                    lists.Add(cn);
                }
                return View(lists);
            }
            var getdata = entit.venues.Where(x => x.isdeletd == 0).OrderByDescending(x => x.createdon).ToList();
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
                cn.fblink = item.fblink;
                cn.district = item.district;
                list.Add(cn);
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
            var filetpe = new SelectList(entit.states.ToList(), "id", "NAME");
            ViewData["Dbstates"] = filetpe;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Custom_venue cp, string message, FormCollection Form)
        {
            if (ModelState.IsValid)
            {
                int active = 0;
                int delete = 0;
                Random generator = new Random();
                string n = generator.Next(0, 999999).ToString("D6");
                venue pv = new venue();
                pv.id = Convert.ToInt32(n);
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                pv.createdon = indianTime;
                pv.address = cp.address;
                pv.venue_area = cp.venue_area;
                pv.phone = cp.phone;
                pv.email = cp.email;
                pv.NAME = cp.NAME;
                pv.fblink = cp.fblink;
                pv.isactive = active;
                pv.isdeletd = delete;
                var statesid = Form["state"];
                int idstate = Convert.ToInt32(statesid);
                var get_O = entit.states.Where(x => x.id == idstate).SingleOrDefault();
                pv.state = get_O.NAME;
                pv.district = pv.district;
                entit.venues.Add(pv);
                entit.SaveChanges();
                return RedirectToAction("Index", "Venue", new { message });

            }
            else
            {
                var filetpe = new SelectList(entit.states.ToList(), "id", "NAME");
                ViewData["Dbstates"] = filetpe;
                return View();
            }
        }

    }
}