using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetUsChat.Controllers
{
    [Route("authentication")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            this.logger = logger;
        }

        [Route("signin")]
        public IActionResult SignIn()
        {
            logger.LogInformation($"Calling {nameof(this.SignIn)}");
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/"
            });
        }

        [Route("signout")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            logger.LogInformation($"Calling {nameof(this.SignOut)}");
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
