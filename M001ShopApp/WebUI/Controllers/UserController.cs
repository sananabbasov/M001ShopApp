using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthManager _authManager;

        public UserController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var token = "test";
            token = _authManager.Login(loginDTO);

            CookieOptions option = new();
            option.Expires = DateTime.UtcNow.AddMinutes(47);
            Response.Cookies.Append("token",token, option);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            try
            {
                _authManager.Register(registerDTO);
                return RedirectToAction("Login");

            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}
