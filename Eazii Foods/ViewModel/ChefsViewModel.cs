using Eazii_Foods.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eazii_Foods.ViewModel
{
    public class ChefsViewModel
    {

        public int? Id { get; set; }
        [Required]
        public string? NameOfChefs { get; set; }
        public string? TypeOfFood { get; set; }
        public int? StateId { get; set; }
        [Display(Name = "state")]
        [ForeignKey("StateId")]
        public State State { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Amount { get; set; }
        [Required]
        public IFormFile? FoodImageUrl { get; set; }
        public string? Image { get; set; }
        public virtual List<Chefs> ActiveChefs { get; set; }
        public virtual List<Chefs> NonActiveChefs { get; set; }

    }
}
