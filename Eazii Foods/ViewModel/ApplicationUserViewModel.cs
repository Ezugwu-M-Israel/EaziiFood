using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eazii_Foods.ViewModel
{
    public class ApplicationUserViewModel
    {

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }
        public string? Department { get; set; }
        public string? Branchoffice { get; set; }
        public int? StateId { get; set; }
        [Display(Name = "state")]
        [ForeignKey("StateId")]
        public string? State { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Password { get; set; }
        public string?  PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}

