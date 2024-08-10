using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("booking_place_guide")]

    public class Booking_Place_Guide
    {
        [Key]
        public int Booking_Place_ID { get; set; }

        [ForeignKey("User_Guide_Bookings")]
        public int? Booking_ID { get; set; }

        [ForeignKey("Guide")]
        public int? Guide_ID { get; set; }

        [ForeignKey("Place")]
        public int? Place_ID { get; set; }

        // Navigation Properties
        public User_Guide_Bookings Booking { get; set; }
        public Guide Guide { get; set; }
        public Place Place { get; set; }
    }
}
