using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Bhatkanti.Models
{
    [Table("user_guide_bookings")]
    public class User_Guide_Bookings
    {
        [Key]
        public int Booking_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        public DateTime Date_To { get; set; }
        public DateTime Date_From { get; set; }
        public TimeSpan Time_From { get; set; }
        public TimeSpan Time_To { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        // Foreign key for Bill
        
        public int? Bill_ID { get; set; }

        [ForeignKey("Guides")]
        public int? Guide_ID { get; set; }

        public Guide Guide { get; set; }

        // Navigation Properties
        public Users User { get; set; }
        public Bill Bill { get; set; }
    }
}
