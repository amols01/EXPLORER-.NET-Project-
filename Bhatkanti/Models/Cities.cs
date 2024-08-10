using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("city")]

    public class Cities
    {
        [Key]
        public int City_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [ForeignKey("M_States")]
        public int? State_ID { get; set; }

        // Navigation Properties
        public M_States State { get; set; }
    }
}
