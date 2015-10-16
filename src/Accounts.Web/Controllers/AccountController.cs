﻿using Accounts.Web.Models;
using Accounts.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Models;
using Models.ViewModel;
using System.Threading.Tasks;

namespace Accounts.Web.Controllers
{
    public class AccountController : BaseController
    {

        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly IOptions<AppSettings> _appSettings;

        public AccountController(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model, string returnUrl = null)
        {
            var user = new ApplicationUser { UserName = model.Login };
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return new ObjectResult(new { message = "campos obrigatórios", status = "error" });

            try
            {
                if (await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false) != SignInResult.Success)
                    return new ObjectResult(new { message = "login inválido", status = "error" });


                var _user = await _userManager.FindByNameAsync(model.Login);
                if (_user == null)
                {
                    await _userManager.CreateAsync(user);
                    user = await _userManager.FindByNameAsync(model.Login);
                }
                else
                    user = _user;
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Erro no servidor: {ex.Message}" });
            }

            return new ObjectResult(new { returnUrl = returnUrl });
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
