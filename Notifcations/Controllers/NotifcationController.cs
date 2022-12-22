using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Notifcations.Hubs;
using Notifcations.Hubs.ServicesHub;
using Notifcations.Models.Entities;
using Notifcations.Utlties.Services;
using Notifcations.ViewModels;

namespace Notifcations.Controllers {
    [Authorize(Roles ="Admin")]
    public class NotifcationController : Controller {
        private readonly IMapper _mapper;
        private readonly IServices _services;
        private readonly UserManager<Appuser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;
        public NotifcationController(IMapper mapper, UserManager<Appuser> userManager, IServices services, IHttpContextAccessor httpContext, IHubContext<NotificationUserHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _services = services;
            _httpContext = httpContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
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
                     
                    }
                }
                ModelState.AddModelError(string.Empty, "مش لاقي البنادم ده");
            }

            return View(model);
        }
    }
}
