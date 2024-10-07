using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("guide_feedback")]

    public class Guide_Feedbacks
    {
        [Key]
        public int Guide_Feedback_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        [ForeignKey("Guide")]
        public int? Guide_ID { get; set; }

        [Required]
        public string Guide_Feedback { get; set; }

        public int? Guide_Rating { get; set; }

       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Users User { get; set; }
        public Guide Guide { get; set; }
    }
}
