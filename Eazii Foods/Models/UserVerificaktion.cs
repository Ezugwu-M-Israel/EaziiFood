using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eazii_Foods.Models
{
    public class UserVerificaktion
    {
        [Key]
        public Guid Token { get; set; }
        public string? UserId { get; set; }
        public bool? Used { get; set; }
        public DateTime DateUsed { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
