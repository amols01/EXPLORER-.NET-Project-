using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("images")]
    public class Images
    {
        [Key]
        public int Image_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Image_Timestamp { get; set; }

        [StringLength(255)]
        public string Image_Description { get; set; }

        // Navigation Properties
        public Users User { get; set; }
    }
}
