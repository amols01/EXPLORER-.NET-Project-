using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhatkanti.Models
{
    [Table("booking_payment_details")]
    public class Booking_Payment_Details
    {
        [Key]
        [StringLength(14)]
        public string Payment_ID { get; set; }

        [ForeignKey("Booking")]
        public int? Booking_ID { get; set; }

        [Required]
        public DateTime Transaction_Date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string Bank_Transaction_Code { get; set; }

        [Required]
        [StringLength(50)]
        public TransactionMode Transaction_Mode { get; set; } // UPI/NetBanking/Cards

        [StringLength(20)]
        public PaymentStatus? Status { get; set; } = null;

        [StringLength(255)]
        public string Remarks { get; set; }

        // Navigation Properties
        public User_Guide_Bookings Booking { get; set; }

        public Booking_Payment_Details()
        {
            // Payment_ID will be set by the service or controller
            //public class PaymentService
            //{
            //    private readonly ApplicationDbContext _context;

            //    public PaymentService(ApplicationDbContext context)
            //    {
            //        _context = context;
            //    }

            //    public string GeneratePaymentID()
            //    {
            //        string datePart = DateTime.UtcNow.ToString("yyyyMMdd"); // 20240805
            //        int sequenceNumber = _context.BookingPaymentDetails
            //            .Count(bp => bp.Payment_ID.StartsWith(datePart)) + 1;

            //        string sequence = sequenceNumber.ToString("D6"); // 000001 format

            //        return datePart + sequence;
            //    }
            //}
        }

        public enum TransactionMode
        {
            UPI,
            NetBanking,
            Cards
        }

        public enum PaymentStatus
        {
            Success,
            Failure
        }
    }
}