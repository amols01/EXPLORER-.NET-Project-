using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Place> Places { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Booking_Payment_Details> Booking_Payment_Details { get; set; }
        public DbSet<Booking_Place_Guide> Booking_Place_Guide { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Feedback_Image> Feedback_Images { get; set; }

        public DbSet<Guide_Feedbacks> Guide_Feedbacks { get; set; }

        public DbSet<Guide_Places> Guide_Places { get; set; }

        public DbSet<Help> Help { get; set; }

        public DbSet<Images> Images { get; set; }

        public DbSet<M_Roles> M_Roles { get; set; }
        //public DbSet<Place> Places { get; set; }

        public DbSet<Place_Feedbacks> Place_Feedbacks { get; set; }

        public DbSet<Place_Images> Place_Images { get; set; }

        public DbSet<User_Guide_Bookings> User_Guide_Bookings { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Wishlist entity
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany() // Users does not have a navigation property back to Wishlist
                .HasForeignKey(w => w.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.City)
                .WithMany() // Cities does not have a navigation property back to Wishlist
                .HasForeignKey(w => w.City_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Place)
                .WithMany() // Place does not have a navigation property back to Wishlist
                .HasForeignKey(w => w.Place_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Bill entity
            modelBuilder.Entity<Bill>()
                .HasMany(b => b.Bookings)
                .WithOne(bk => bk.Bill)
                .HasForeignKey(bk => bk.Bill_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure User_Guide_Bookings entity
            modelBuilder.Entity<User_Guide_Bookings>()
                .HasOne(ub => ub.Bill)
                .WithMany(b => b.Bookings)
                .HasForeignKey(ub => ub.Bill_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_Guide_Bookings>()
                .HasOne(ub => ub.User)
                .WithMany() // Users does not have a navigation property back to User_Guide_Bookings
                .HasForeignKey(ub => ub.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            

            // Configure Booking_Place_Guide entity
            modelBuilder.Entity<Booking_Place_Guide>()
                .HasOne(bpg => bpg.Booking)
                .WithMany() // Booking does not have a navigation property back to Booking_Place_Guide
                .HasForeignKey(bpg => bpg.Booking_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking_Place_Guide>()
                .HasOne(bpg => bpg.Place)
                .WithMany() // Place does not have a navigation property back to Booking_Place_Guide
                .HasForeignKey(bpg => bpg.Place_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Cities entity
            modelBuilder.Entity<Cities>()
                .HasOne(c => c.State)
                .WithMany() // State does not have a navigation property back to Cities
                .HasForeignKey(c => c.State_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Feedback_Image entity
            modelBuilder.Entity<Feedback_Image>()
                .HasOne(fi => fi.Image)
                .WithMany() // Image does not have a navigation property back to Feedback_Image
                .HasForeignKey(fi => fi.Image_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Guide entity
            modelBuilder.Entity<Guide>()
                .HasOne(g => g.User)
                .WithMany() // Users does not have a navigation property back to Guide
                .HasForeignKey(g => g.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Guide_Feedbacks entity
            modelBuilder.Entity<Guide_Feedbacks>()
                .HasOne(gf => gf.User)
                .WithMany() // Users does not have a navigation property back to Guide_Feedbacks
                .HasForeignKey(gf => gf.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Help entity
            modelBuilder.Entity<Help>()
                .HasOne(h => h.User)
                .WithMany() // Users does not have a navigation property back to Help
                .HasForeignKey(h => h.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Images entity
            modelBuilder.Entity<Images>()
                .HasOne(i => i.User)
                .WithMany() // Users does not have a navigation property back to Images
                .HasForeignKey(i => i.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Place_Feedbacks entity
            modelBuilder.Entity<Place_Feedbacks>()
                .HasOne(pf => pf.User)
                .WithMany() // Users does not have a navigation property back to Place_Feedbacks
                .HasForeignKey(pf => pf.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Place_Images entity
            modelBuilder.Entity<Place_Images>()
                .HasOne(pi => pi.Image)
                .WithMany() // Image does not have a navigation property back to Place_Images
                .HasForeignKey(pi => pi.Image_ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User_Guide_Bookings>()
       .HasOne(ugb => ugb.Guide)
       .WithMany() // Or use WithMany(g => g.UserGuideBookings) if you have a navigation property
       .HasForeignKey(ugb => ugb.Guide_ID)
       .OnDelete(DeleteBehavior.Restrict); // or another delete behavior

            modelBuilder.Entity<User_Guide_Bookings>()
                .HasOne(ugb => ugb.User)
                .WithMany() // Or use WithMany(u => u.UserGuideBookings) if you have a navigation property
                .HasForeignKey(ugb => ugb.User_ID)
                .OnDelete(DeleteBehavior.Restrict); // or another delete behavior

            base.OnModelCreating(modelBuilder);
            //  base.OnModelCreating(modelBuilder);

            /*   modelBuilder.Entity<Users>()
                   .HasOne(u => u.Roles)
                   .WithMany()
                   .HasForeignKey(u => u.Role_ID)
                   .OnDelete(DeleteBehavior.Restrict);

               base.OnModelCreating(modelBuilder);

               // Configure Users entity
               modelBuilder.Entity<Users>()
                   .HasOne(u => u.Roles)
                   .WithMany() // M_Roles does not have a navigation property back to Users
                   .HasForeignKey(u => u.Role_ID)
                   .OnDelete(DeleteBehavior.Restrict);*/
        }

    }
}