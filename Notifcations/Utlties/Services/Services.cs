using Microsoft.AspNetCore.Identity;
using Notifcations.Models.Entities;

namespace Notifcations.Utlties.Services {
    public class Services : IServices {
        private readonly SignInManager<Appuser> _signInManager;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Services(SignInManager<Appuser> signInManager, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> EmailTakenByAnotherUser(string email)
        {
            return await _userManager.FindByEmailAsync(email)==null?true:false;
        }

        public async Task<bool> RoleIsExist(string role)
        {
           return await _roleManager.RoleExistsAsync(role);
        }
    }
}
