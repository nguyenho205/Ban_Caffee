using Ban_Caffee.Models;
using Ban_Caffee.Models.Dto;
using Ban_Caffee.Models.ViewModel;
using Ban_Caffee.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Ban_Caffee.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        private readonly ICustomerAuthService _customerAuthService;

        public UserController(ICustomerAuthService customerAuthService)
        {
            _customerAuthService = customerAuthService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", " Email hoặc mật khẩu không đúng.");
                return View();
            }

            var model = new CustomerLoginViewModel()
            {
                Email = Email,
                Password = Password
            };

            var tokenData = await _customerAuthService.LoginAsync(model);

            if (tokenData != null && !string.IsNullOrEmpty(tokenData.AccessToken))
            {
                HttpContext.Session.SetString("CustomerAuthToken", tokenData.AccessToken);
                if (!string.IsNullOrEmpty(tokenData.CustomerName))
                    HttpContext.Session.SetString("CustomerName", tokenData.CustomerName);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            return View();
        }
        //dang ky
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Mật khẩu xác nhận không khớp.");
                return View(model);
            }

            var result = await _customerAuthService.RegisterAsync(model);

            if (result != null && result.IsSuccess)
            {
                TempData["RegisterSuccess"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction("Login", "User");
            }

            ModelState.AddModelError("", result?.Message ?? "Đăng ký thất bại. Vui lòng thử lại!");
            return View(model);
        }
    }


}
