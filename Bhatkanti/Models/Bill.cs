using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("bill")]
    public class Bill
    {
        [Key]
        public int Bill_ID { get; set; }

        // Foreign key for User_Guide_Bookings
        public int? Booking_ID { get; set; }

        [Required]
        public decimal Total_Guide_Fee { get; set; }

        [Required]
        public decimal GST { get; set; }

        [Required]
        public decimal Platform_Fee { get; set; }

        [Required]
        public decimal Total_Bill_Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [ForeignKey("Guide_ID")]
        public Guide? Guide { get; set; }
        // Navigation Properties
        public ICollection<User_Guide_Bookings> Bookings { get; set; }
    }
} 