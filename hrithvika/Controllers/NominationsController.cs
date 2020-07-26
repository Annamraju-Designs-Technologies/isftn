using System;
using hrithvika.Entities;
using hrithvika.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hrithvika.Controllers
{
    public class NominationsController : Controller
    {
        // GET: Nominations
        ph16787236639_Entities entit = new ph16787236639_Entities();
        public ActionResult Index()
        {
            var getdata=entit.Nominations.Where(x => x.isactive == 1 && x.isdeleted == 0).ToList();
            List<Custom_Nomination> list = new List<Custom_Nomination>();
            foreach (var item in getdata)
            {
                Custom_Nomination cn = new Custom_Nomination();
                cn.id = item.id;
                cn.NAME = item.NAME;
                cn.title = item.title;
                cn.phone = item.phone;
                cn.display_image = item.display_image;
                cn.video = item.video;
                cn.Description = item.Description;
                list.Add(cn);
            }
            return View(list);
        }
        public ActionResult Nominationtype(string type)
        {
            var getdata = entit.Nominations.Where(x => x.isactive == 1 &&x.category==type &&x.isdeleted==0).ToList();
            List<Custom_Nomination> list = new List<Custom_Nomination>();
            foreach (var item in getdata)
            {
                Custom_Nomination cn = new Custom_Nomination();
                cn.id = item.id;
                cn.NAME = item.NAME;
                cn.title = item.title;
                cn.phone = item.phone;
                cn.display_image = item.display_image;
                cn.video = item.video;
                cn.Description = item.Description;
                list.Add(cn);
            }
            return View(list);
        }
        public ActionResult Nominationdetails(int eventID)
        {
            var getdata = entit.Nominations.Where(x => x.id == eventID).SingleOrDefault();
            Custom_Nomination cn = new Custom_Nomination();
            cn.id = getdata.id;
            cn.NAME = getdata.NAME;
            cn.title = getdata.title;
            cn.video = getdata.video;
            cn.Description = getdata.Description;
            return View(cn);
        }
    }
}