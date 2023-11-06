using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BilgeShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("KayitOl")]
        public IActionResult Register()
           
        { 
            return View();
        }

        [HttpPost]
        [Route("KayitOl")]
        public IActionResult Register(RegisterViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View();
                //form datayı parametre olarak  geri göndererek formda doldurulmuş yerleri sıfırlamayı sağlıyoruz
            }
                var addUserDto = new AddUserDto()
                {
                    Email = formData.Email.Trim(),
                    FirstName = formData.FirstName.Trim(),
                    LastName = formData.LastName.Trim(),
                    Password = formData.Password.Trim(),


                };
                var result = _userService.AddUser(addUserDto);

                if (result.IsSucceed)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ErrorMessage =result.Message;
                    return View(formData);
                }
                
            }
        
           public async Task<IActionResult> login(LoginViewModel formData)
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
            var loginDto = new LoginDto
            {
                Email = formData.Email,
                Password = formData.Password
            };
            var userInfo = _userService.LoginUser(loginDto);
            if (userInfo is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim("id",userInfo.Id.ToString()));
            claims.Add(new Claim("email", userInfo.Email.ToString()));
            claims.Add(new Claim("firstName", userInfo.FirstName.ToString()));
            claims.Add(new Claim("lastName", userInfo.LastName.ToString()));
            claims.Add(new Claim("userType", userInfo.UserType.ToString()));
            ///yetkilendirme işlemi için özel olarak bir claim daha açılacak


            claims.Add(new Claim(ClaimTypes.Role, userInfo.UserType.ToString()));

            var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {

                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48))


            };
            await HttpContext.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimIdentity), autProperties);

            return RedirectToAction("Index", "Home");
            }

        public async Task<IActionResult>Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        }
      
    }

