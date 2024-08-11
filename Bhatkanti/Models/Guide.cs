using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhatkanti.Models
{
    [Table("guide")]
    public class Guide
    {
        [Key]
        public int Guide_ID { get; set; }

        [ForeignKey("Users")]
        public int? User_ID { get; set; }

        

        [Required]
        [StringLength(12)]
        public string Aadhar_Number { get; set; }

       // [Required]
        [StringLength(10)]
        public string PAN_Number { get; set; }

        [Required]
        [StringLength(20)]
        public string Account_Number { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        // Navigation Properties
        public Users? User { get; set; }

       
    }
}