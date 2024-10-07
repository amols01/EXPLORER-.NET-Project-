using Bhatkanti_.Models;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti_.Data
{
    public class TravelGuideContext : DbContext
    {
        public TravelGuideContext(DbContextOptions<TravelGuideContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<UserGuideBooking> UserGuideBookings { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<GuideFeedback> GuideFeedbacks { get; set; }
        public DbSet<PlaceFeedback> PlaceFeedbacks { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<GuideVerification> GuideVerifications { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.GuideFeedbacks)
                .WithOne(gf => gf.User)
                .HasForeignKey(gf => gf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PlaceFeedbacks)
                .WithOne(pf => pf.User)
                .HasForeignKey(pf => pf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Wishlists)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Guide entity
            modelBuilder.Entity<Guide>()
                .HasKey(g => g.GuideId);

            modelBuilder.Entity<Guide>()
                .HasMany(g => g.GuideFeedbacks)
                .WithOne(gf => gf.Guide)
                .HasForeignKey(gf => gf.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure UserGuideBooking entity
            modelBuilder.Entity<UserGuideBooking>()
                .HasKey(ugb => ugb.BookingId);

            modelBuilder.Entity<UserGuideBooking>()
                .HasMany(ugb => ugb.GuideFeedbacks)
                .WithOne(gf => gf.UserGuideBooking)
                .HasForeignKey(gf => gf.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Bill entity
            modelBuilder.Entity<Bill>()
                .HasKey(b => b.BillId);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.UserGuideBooking)
                .WithMany(ugb => ugb.Bills)
                .HasForeignKey(b => b.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Guide)
                .WithMany(g => g.Bills)
                .HasForeignKey(b => b.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure GuideFeedback entity
            modelBuilder.Entity<GuideFeedback>()
                .HasKey(gf => gf.FeedbackId);

            modelBuilder.Entity<GuideFeedback>()
                .HasOne(gf => gf.User)
                .WithMany(u => u.GuideFeedbacks)
                .HasForeignKey(gf => gf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuideFeedback>()
                .HasOne(gf => gf.Guide)
                .WithMany(g => g.GuideFeedbacks)
                .HasForeignKey(gf => gf.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuideFeedback>()
                .HasOne(gf => gf.UserGuideBooking)
                .WithMany(ugb => ugb.GuideFeedbacks)
                .HasForeignKey(gf => gf.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure PlaceFeedback entity
            modelBuilder.Entity<PlaceFeedback>()
                .HasKey(pf => pf.PlaceFeedbackId);

            modelBuilder.Entity<PlaceFeedback>()
                .HasOne(pf => pf.User)
                .WithMany(u => u.PlaceFeedbacks)
                .HasForeignKey(pf => pf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaceFeedback>()
                .HasOne(pf => pf.Location)
                .WithMany(l => l.PlaceFeedbacks)
                .HasForeignKey(pf => pf.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Wishlist entity
            modelBuilder.Entity<Wishlist>()
                .HasKey(w => w.WishlistId);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Location)
                .WithMany(l => l.Wishlists)
                .HasForeignKey(w => w.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Admin entity
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Email);

            // Configure Location entity
            modelBuilder.Entity<Location>()
                .HasKey(l => l.PlaceId);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.PlaceFeedbacks)
                .WithOne(pf => pf.Location)
                .HasForeignKey(pf => pf.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Wishlists)
                .WithOne(w => w.Location)
                .HasForeignKey(w => w.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure City entity
            modelBuilder.Entity<City>()
                .HasKey(c => c.CityId);

            // Configure GuideVerification entity
            modelBuilder.Entity<GuideVerification>()
                .HasKey(gv => gv.AadharNumber);

            modelBuilder.Entity<GuideVerification>()
                .HasOne(gv => gv.Guide)
                .WithOne(g => g.GuideVerification)
                .HasForeignKey<GuideVerification>(gv => gv.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}