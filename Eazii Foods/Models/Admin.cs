using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace Eazii_Foods.Models
{
    public class Admin
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Department { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }

        public string? Branchoffice { get; set; }
        public int? StateId { get; set; }
        [Display(Name = "state")]
        [ForeignKey("StateId")]
        public State State { get; set; }

    }
}
