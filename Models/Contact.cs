using System;
using System.ComponentModel.DataAnnotations;   // Add injection to add validation annotation


namespace aspconsoleapp.Models
{
    public class Contact
    {
        public int id { get; set; }

        [Required, MaxLength(30)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display (Name="EmailAddress")]
        public string EmailAddress { get; set; }

    }


}