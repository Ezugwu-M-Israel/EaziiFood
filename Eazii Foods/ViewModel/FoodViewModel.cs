using Eazii_Foods.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eazii_Foods.ViewModel
{
    public class FoodViewModel
    {

     
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? DateCreated { get; set; }
        public string? Image { get; set; }


    }
}
