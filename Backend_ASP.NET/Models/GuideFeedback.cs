
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("guide_feedback")]
    public class GuideFeedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        [ForeignKey("UserGuideBooking")]
        public int BookingId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string? Comment { get; set; }

        public User? User { get; set; }
        public Guide? Guide { get; set; }
        public UserGuideBooking? UserGuideBooking { get; set; }
    }
}
