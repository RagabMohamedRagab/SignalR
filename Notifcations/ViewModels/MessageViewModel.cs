using Notifcations.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Notifcations.ViewModels {
    public class MessageViewModel {
        [Required(ErrorMessage = " هنا يلا")]
        public string Text { get; set;}
        [Required(ErrorMessage = "اكتب هنا يلا")]
        public string UserId { get; set; }
    }
}
