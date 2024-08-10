using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public byte[]? Profile_Image { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public int? Image_ID { get; set; }

        [Required]
        [ForeignKey("Role_ID")]
        public int Role_ID { get; set; }

        
        

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        // Navigation Properties
        public ICollection<Guide> Guides { get; set; } = new List<Guide>();
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public ICollection<Feedback_Image> FeedbackImages { get; set; } = new List<Feedback_Image>();
        public ICollection<Place_Feedbacks> PlaceFeedbacks { get; set; } = new List<Place_Feedbacks>();
        public ICollection<Help> Helps { get; set; } = new List<Help>();
        public ICollection<Images> Images { get; set; } = new List<Images>();
    }
}
