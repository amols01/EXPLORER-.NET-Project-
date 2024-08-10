using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("guide_places")]
    public class Guide_Places
    {
        [Key]
        public int GP_ID { get; set; }

        [ForeignKey("Guide")]
        public int? Guide_ID { get; set; }

        [ForeignKey("Place")]
        public int? Place_ID { get; set; }

        [Required]
        public decimal Guide_Fee { get; set; }

        // Navigation Properties
        public Guide Guide { get; set; }
        public Place Place { get; set; }
    }
}
