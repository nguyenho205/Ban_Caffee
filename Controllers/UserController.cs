using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Ban_Caffee.Models;

namespace Ban_Caffee.Controllers
{
    public class UserController : Controller
    {
        
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
     
        [HttpPost]
    public ActionResult LoginSubmit(string email, string password)
    {
        
         
            string validEmail = "a@gmail.com";
            string validPassword = "123456";

            // Kiểm tra hợp lệ
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin!";
                return View("Login");
            }

            if (email != validEmail || password != validPassword)
            {
                ViewBag.Error = "Email hoặc mật khẩu không chính xác!";
                return View("Login");
            }

            // ✅ Thành công → chuyển về Home/Index
            TempData["Success"] = "Đăng nhập thành công!";
            return RedirectToAction("Index", "Home");
    }
    

        private static List<User> users = new List<User>
    {
        new User { Name = "Nguyen Van A", Email = "a@gmail.com", Password = "123456" }
    };

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterSubmit(string Name, string Email, string Password, string ConfirmPassword)
    {
        // Kiểm tra trùng email
        var existingUser = users.FirstOrDefault(u => u.Email.Equals(Email, StringComparison.OrdinalIgnoreCase));
        if (existingUser != null)
        {
            ViewBag.Error = "Email này đã được sử dụng!";
            return View("Register");
        }

        // Kiểm tra khớp mật khẩu
        if (Password != ConfirmPassword)
        {
            ViewBag.Error = "Mật khẩu xác nhận không khớp!";
            return View("Register");
        }

        // Thêm tài khoản mới
        users.Add(new User { Name = Name, Email = Email, Password = Password });

        // Redirect về trang chủ sau khi đăng ký thành công
        return RedirectToAction("Index", "Home");
    }


    }
}