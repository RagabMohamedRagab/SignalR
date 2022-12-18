using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notifcations.Models.Entities;
using Notifcations.Utlties.Configurtions;
using Notifcations.Utlties.Services;
using Notifcations.ViewModels;
using System.Data;

namespace Notifcations.Controllers {
    //[Authorize]
    public class AccountController : Controller {
        private readonly SignInManager<Appuser> _signInManager;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _role;

        private readonly IServices _services;

        public AccountController(SignInManager<Appuser> signInManager, UserManager<Appuser> userManager, IServices services, RoleManager<IdentityRole> role)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _services = services;
            _role = role;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_services.EmailTakenByAnotherUser(model.Email).Result)
                {
                    Appuser identity = new Appuser()
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        PasswordHash = model.Password,
                    };
                    // -- Create User
                    var result = await _userManager.CreateAsync(identity, model.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(String.Empty, item.Description);
                        }
                        return View(model);
                    }
                    await _signInManager.SignInAsync(identity, false);
                    // Roles
                    if (_services.RoleIsExist(Role.User).Result)
                    {
                        var Assign_Rol = await _userManager.AddToRoleAsync(identity, Role.User);
                        if (!Assign_Rol.Succeeded)
                        {
                            foreach (var item in Assign_Rol.Errors)
                            {
                                ModelState.AddModelError(String.Empty, item.Description);
                            }
                            return View(model);
                        }
                        HttpContext.Session.SetString("UserName", model.Email);
                        return View("Done");
                    }
                }
                ModelState.AddModelError(string.Empty, "Email is taken by another user");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.SetString("UserName", "");
            return View("Done");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.Returnurl = ReturnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Appuser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RemmberMe, false);
                    ViewBag.IsAdmin =await _userManager.IsInRoleAsync(user, "Admin");
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Email or Password are not Correct");
                    }

                    else
                    {
                        HttpContext.Session.SetString("UserName", user.Email);
                        return View("Done");
                    }
                }
                ModelState.AddModelError(string.Empty, "مش لاقي البنادم ده");
            }
            return View(model);
        }
    }
}



