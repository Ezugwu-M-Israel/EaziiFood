using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eazii_Foods.Models
{
    public class Chefs
    {        
        public int? Id { get; set; }
        [Required]
        public string? NameOfChefs { get; set; }
        public string? TypeOfFood { get; set; }
        public string? Amount { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile FoodImageUrl { get; set; }
    }
}
