using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notifcations.Models.Entities;
using Notifcations.Utlties.Services;
using Notifcations.ViewModels;

namespace Notifcations.Controllers {
    [Authorize(Roles ="Admin")]
    public class NotifcationController : Controller {
        private readonly IMapper _mapper;
        private readonly IServices _services;
        private readonly UserManager<Appuser> _userManager;
        public NotifcationController(IMapper mapper, UserManager<Appuser> userManager, IServices services)
        {
            _mapper = mapper;
            _userManager = userManager;
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            IEnumerable<Appuser> appusers = await _userManager.GetUsersInRoleAsync("User");
            ViewBag.Users = new SelectList(appusers.Select(b => b.Email));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.UserId);
                if (user != null)
                {
                    model.UserId = user.Id;
                    var message = _mapper.Map<Message>(model);
                    if (_services.CreateMessage(message).Result > 0)
                    {
                        // Configure to Send 
                    }
                }
                ModelState.AddModelError(string.Empty, "مش لاقي البنادم ده");
            }

            return View(model);
        }
    }
}
