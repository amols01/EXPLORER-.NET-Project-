using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti.Models
{
    [Table("m_states")]
    public class M_States
    {
        [Key]
        public int State_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }
    }
}