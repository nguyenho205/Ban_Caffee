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
            var email = collection["email"];
            var password = collection["password"];

            tblKhachHang kh = db.tblKhachHang.FirstOrDefault(x => x.Email == email && x.MatKhau == password);
            if (kh != null)
            {
                Session["User"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Email hoặc mật khẩu không đúng!";

            return View("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSubmit(FormCollection collection, tblKhachHang kh)
        {
            var name = collection["name"];
            var email = collection["email"];
            var password = collection["password"];


            kh.TenKH = name;
            kh.Email = email;
            kh.MatKhau = password;


            db.tblKhachHang.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Login");
        }


    }
}