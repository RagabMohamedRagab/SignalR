using System.ComponentModel.DataAnnotations;

namespace Notifcations.ViewModels {
    public class RegisterViewModel {
        [Required(ErrorMessage ="اكتب هنا يلا")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="اكتب هنا يلا")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "اكتب هنا يلا")]
        [Compare("Password", ErrorMessage = "اغثوناااااا من الزبون ده")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
