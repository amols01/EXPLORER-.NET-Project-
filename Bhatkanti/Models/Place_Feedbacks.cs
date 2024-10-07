using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("place_feedback")]
    public class Place_Feedbacks
    {
        [Key]
        public int Place_Feedback_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        [ForeignKey("Place")]
        public int? Place_ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [Required]
        public string Place_Feedback { get; set; }

        public int? Place_Rating { get; set; } 

        // Navigation Properties
        public Users User { get; set; }
        public Place Place { get; set; }
    }
}
