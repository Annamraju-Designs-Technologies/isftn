using hrithvika.Entities;
using hrithvika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hrithvika.Controllers
{
   [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ph16787236639_Entities entit = new ph16787236639_Entities();
                var validate = entit.admins.Where(x => x.username == model.UserName && x.PASSWORD == model.Password).SingleOrDefault();
                if (validate != null)
                {
                    FormsAuthentication.SetAuthCookie(validate.username, false);
                    return RedirectToAction("Index", "Admin");
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The Username or Password provided is incorrect.");
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}