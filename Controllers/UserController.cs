using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace LTWeb_Buoi10.Controllers
{
    public class UserController : Controller
    {
        
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginSubmit(FormCollection collection)
        {
            

            return View("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSubmit(FormCollection collection)
        {
            
            return RedirectToAction("Login");
        }


    }
}