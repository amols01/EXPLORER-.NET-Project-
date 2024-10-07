
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti_.Models
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        [ForeignKey("UserGuideBooking")]
        public int BookingId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GuideFees { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GST { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PlatformFees { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime Timestamp { get; set; }

        public UserGuideBooking? UserGuideBooking { get; set; }
        public Guide? Guide { get; set; }
    }
}
