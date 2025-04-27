using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please enter the first name")]
        public string ? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name")]
        public string ? LastName { get; set; }
        [Required(ErrorMessage ="Please enter the Email")]
        [Display (Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email address")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "Please enter the strong Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [Display (Name ="Password")]
        [DataType (DataType.Password)]
        public string ? Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ? ConfirmPassword { get; set; }
    }
}
