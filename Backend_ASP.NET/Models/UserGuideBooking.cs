
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("user_guide_booking")]
    public class UserGuideBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        [Required]
        [StringLength(255)]
        public string? Location { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime BookingStartTime { get; set; }

        public DateTime BookingEndTime { get; set; }

        public User? User { get; set; }
        public Guide? Guide { get; set; }

        public ICollection<GuideFeedback>? GuideFeedbacks { get; set; }
        public ICollection<Bill>? Bills { get; set; }
    }
}
