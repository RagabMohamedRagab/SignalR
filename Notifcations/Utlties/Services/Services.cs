using Microsoft.AspNetCore.Identity;
using Notifcations.Models;
using Notifcations.Models.Entities;

namespace Notifcations.Utlties.Services {
    public class Services : IServices {
        private readonly SignInManager<Appuser> _signInManager;
        private readonly UserManager<Appuser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public Services(SignInManager<Appuser> signInManager, UserManager<Appuser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<int> CreateMessage(Message message)
        {
            _context.Add<Message>(message);
            return await _context.SaveChangesAsync();
 
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
