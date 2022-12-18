using Notifcations.Models.Entities;

namespace Notifcations.ViewModels {
    public class MessageViewModel {
        public string Message { get; set; }
        public virtual ICollection<Appuser> Users { get; set; }
    }
}
