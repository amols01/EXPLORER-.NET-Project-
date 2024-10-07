
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Guide_verification")]
    public class GuideVerification
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string? AadharNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string? PanNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string? AccountNumber { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        public DateTime? Timestamp { get; set; }

        public Guide? Guide { get; set; }
    }
}
