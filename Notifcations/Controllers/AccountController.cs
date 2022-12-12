using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notifcations.Utlties.Configurtions;
using Notifcations.Utlties.Services;
using Notifcations.ViewModels;
using System.Data;

namespace Notifcations.Controllers {
    
    public class AccountController : Controller {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;

        private readonly IServices _services;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IServices services, RoleManager<IdentityRole> role)
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
                    IdentityUser identity = new IdentityUser()
                    {
                        UserName = model.Email,
                        Email=model.Email,
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
                        return View("Done");
                    }
                }
                ModelState.AddModelError(string.Empty, "Email is taken by another user");
            }
            return View(model);
        }
       
    }
}
