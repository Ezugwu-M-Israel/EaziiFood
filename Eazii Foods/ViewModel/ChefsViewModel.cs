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
        public string? Amount { get; set; }
        [Required]
        public IFormFile FoodImageUrl { get; set; }
        public string? Image { get; set; }

    }
}
