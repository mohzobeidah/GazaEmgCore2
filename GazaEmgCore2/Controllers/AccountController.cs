using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GazaEmgCore2.Domain;
using GazaEmgCore2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GazaEmgCore2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager , SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;

        }
        public async Task<IActionResult> Login(string returnUrl = null)
        {
                //if (!string.IsNullOrEmpty(ErrorMessage))
                //{
                //    ModelState.AddModelError(string.Empty, ErrorMessage);
                //}

                returnUrl = returnUrl ?? Url.Content("~/");

                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                

                ViewBag.ReturnUrl = returnUrl;
                return View();
        }

        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                
                if (result.IsLockedOut)
                {
                    //_logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            //_logger.LogInformation("User logged out.");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()

        {
            //_logger.LogInformation("User AccessDenied .");
            return View();
        }


        public  IActionResult Register()

        {
            //_logger.LogInformation("User AccessDenied .");
            return View();
        }

    }
}