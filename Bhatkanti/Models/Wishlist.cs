using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("wishlist")]
    public class Wishlist
    {
        [Key]
        public int Wishlist_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        [ForeignKey("Cities")]
        public int? City_ID { get; set; }

        [ForeignKey("Place")]
        public int? Place_ID { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Users User { get; set; }
        public Cities City { get; set; }
        public Place Place { get; set; }

    }
}
