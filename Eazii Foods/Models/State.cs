using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eazii_Foods.Models
{
    public class State:BaseModel
    {
        public int? CountryId { get; set; }
        [Display(Name = "Country")]
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }
    }
}
