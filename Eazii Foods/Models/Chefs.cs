using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Eazii_Foods.Models
{
    public class Chefs
    {
        [Key]
        public int? Id { get; set; }
        public string? TypeOfFood { get; set; }
        public int? StateId { get; set; }
        [Display(Name = "state")]
        [ForeignKey("StateId")]
        public State State { get; set; }
        public string? NameOfChefs { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Amount { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? FoodImageUrl { get; set; }


    }
}
