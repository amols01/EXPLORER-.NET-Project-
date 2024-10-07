using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("place")]
    public class Place
    {
        [Key]
        public int Place_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Place_Name { get; set; }

        [ForeignKey("City")]
        public int? City_ID { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string Nearest_PS { get; set; }

        // Navigation Properties
        public Cities City { get; set; }
    }
}
