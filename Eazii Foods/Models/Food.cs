using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eazii_Foods.Models
{
    public class Food
    {
        
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string? Image { get; set; }
    }
}




