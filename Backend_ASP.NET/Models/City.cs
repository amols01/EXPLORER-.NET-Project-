
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Required]
        [StringLength(100)]
        public string? CityName { get; set; }

        [Required]
        [StringLength(100)]
        public string? State { get; set; }

        public ICollection<Location>? Locations { get; set; }
    }
}
