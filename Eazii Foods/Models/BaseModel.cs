using System.ComponentModel.DataAnnotations;

namespace Eazii_Foods.Models
{
    public class BaseModel 
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
