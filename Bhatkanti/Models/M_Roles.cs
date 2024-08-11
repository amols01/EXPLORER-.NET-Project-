using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti.Models
{
    [Table("m_roles")]
    public class M_Roles
    {
        [Key]
        public int Role_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
