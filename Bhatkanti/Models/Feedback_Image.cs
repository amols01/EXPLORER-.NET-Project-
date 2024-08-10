using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("place_feedback_images")]
    public class Feedback_Image
    {
        [Key] // Single primary key
        public int Feedback_Image_Id { get; set; }

        [ForeignKey("Place_Feedback")]
        public int Place_Feedback_ID { get; set; }

        [ForeignKey("Images")]
        public int Image_ID { get; set; }

        // Navigation Properties
        public Place_Feedbacks Place_Feedback { get; set; }
        public Images Image { get; set; }
    }
}
