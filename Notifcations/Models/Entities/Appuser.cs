using Microsoft.AspNetCore.Identity;

namespace Notifcations.Models.Entities {
    public class Appuser:IdentityUser {
        public virtual ICollection<Message> Messages { get; set; }
    }
}
