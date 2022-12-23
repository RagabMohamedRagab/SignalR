using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Notifcations.Controllers {
    [Authorize(Roles = "User")]
    public class ChattingController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
