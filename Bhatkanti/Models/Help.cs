using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("help")]
    public class Help
    {
        [Key]
        public int Help_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone_Number { get; set; }

        public string Query { get; set; }
        public string Answer { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; } 

        // Navigation Properties
        public Users User { get; set; }
    }
}
