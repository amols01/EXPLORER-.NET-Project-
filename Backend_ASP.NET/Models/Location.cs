using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceId { get; set; }

        [Required]
        [StringLength(255)]
        public string? PlaceName { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Image")]
        public string? Image { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? NearestPS { get; set; }

        public City? City { get; set; }

        public ICollection<PlaceFeedback>? PlaceFeedbacks { get; set; }
        public ICollection<Wishlist>? Wishlists { get; set; }
    }
}
