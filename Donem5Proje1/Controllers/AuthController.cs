using AuthAPI.Models;
using AuthAPI;
using Microsoft.AspNetCore.Mvc;

namespace Donem5Proje1.Controllers
{
    public class AuthController : Controller
    {
        public static string Token = string.Empty;
        public IActionResult Index() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterPostModel registerPostModel)
        {
            var content = await AuthService.Register(registerPostModel);

            if (content?.Status == "Success")
            {
                return View("Index", content);

            }
            else
            {
                return View("Index", content);
            }
            //return RedirectToAction("Index", "Home", content);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginPostModel loginPostModel)
        {
            var content = await AuthService.Login(loginPostModel);

            Token = content?.Token;

            return RedirectToAction("Index", "Home");

        }
    }
}
