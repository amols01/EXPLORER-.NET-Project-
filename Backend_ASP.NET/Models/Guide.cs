
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Guide")]
    public class Guide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuideId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        public DateTime? Timestamp { get; set; }

        public ICollection<GuideFeedback>? GuideFeedbacks { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public GuideVerification? GuideVerification { get; set; }
    }
}
