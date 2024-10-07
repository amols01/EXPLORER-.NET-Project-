
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        public DateTime Timestamp { get; set; }
        public ICollection<GuideFeedback>? GuideFeedbacks { get; set; } = new List<GuideFeedback>();
        public ICollection<PlaceFeedback>? PlaceFeedbacks { get; set; } = new List<PlaceFeedback>();
        public ICollection<Wishlist>? Wishlists { get; set; } = new List<Wishlist>();

    }
}
