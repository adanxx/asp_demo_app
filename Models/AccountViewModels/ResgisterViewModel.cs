using System.ComponentModel.DataAnnotations;

namespace aspconsoleapp.Models.AccountViewModels
{
    public class ResgisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage="The Password must be least {2} and max {1} charater long,", MinimumLength=6)]
        public string Password { get; set; }
       
       
         [Required]
         [DataType(DataType.Password)]
         [Display(Name="Confirm password")]
         [Compare("Password", ErrorMessage=" The passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}