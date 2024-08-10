using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("place_images")]
    public class Place_Images
    {
        [Key] // Single primary key
        public int Place_Image_Id { get; set; }

        [ForeignKey("Place")]
        public int Place_ID { get; set; }

        [ForeignKey("Images")]
        public int Image_ID { get; set; }

        // Navigation Properties
        public Place Place { get; set; }
        public Images Image { get; set; }
    }
}
