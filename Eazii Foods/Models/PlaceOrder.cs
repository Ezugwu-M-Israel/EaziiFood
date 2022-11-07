using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eazii_Foods.Models
{
    public class PlaceOrder : BaseModel
    {
        public string? UserId { get; set; }
        [Display(Name = "User")]
        [ForeignKey("UserId")]

        public virtual ApplicationUser? User { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public string? PhoneNumber { get; set; }

        public int? FoodId { get; set; }
        [Display(Name = "Food")]
        [ForeignKey("FoodId")]
        public virtual Food? Food { get; set; }

        public int? StateId { get; set; }
        [Display(Name = "state")]
        [ForeignKey("StateId")]
        public virtual State? State { get; set; }
    }
}
