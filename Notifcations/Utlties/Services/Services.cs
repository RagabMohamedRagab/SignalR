using Microsoft.AspNetCore.Identity;

namespace Notifcations.Utlties.Services {
    public class Services : IServices {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Services(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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
