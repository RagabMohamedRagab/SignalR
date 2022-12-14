using System.ComponentModel.DataAnnotations;

namespace Notifcations.ViewModels {
    public class LoginViewModel {
        [EmailAddress]
        [Required(ErrorMessage = "اكتب هنا يلا")]
        public string Email { get; set; }
        [Required(ErrorMessage = "اكتب هنا يلا")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remmber Me")]
        public bool RemmberMe { get; set; }
       
    }
}
