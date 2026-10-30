
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    public class AppDbContext(
        DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // Database tables
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Room configuration
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.RoomId);

                entity.Property(r => r.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(r => r.RoomType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(r => r.PricePerNight)
                    .IsRequired()
                    .HasPrecision(10, 2);

                entity.Property(r => r.IsAvailable)
                    .IsRequired();
            });

            // Guest configuration
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(g => g.GuestId);

                entity.Property(g => g.GuestName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(g => g.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(g => g.Phone)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            // Booking configuration
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.BookingId);

                entity.Property(b => b.GuestId)
                    .IsRequired();

                entity.Property(b => b.RoomId)
                    .IsRequired();

                entity.Property(b => b.CheckInDate)
                    .IsRequired();

                entity.Property(b => b.CheckOutDate)
                    .IsRequired();

                entity.Property(b => b.BookingStatus)
                    .IsRequired()
                    .HasMaxLength(30);

                // One guest can have multiple bookings
                entity.HasOne(b => b.Guest)
                    .WithMany()
                    .HasForeignKey(b => b.GuestId)
                    .OnDelete(DeleteBehavior.Restrict);

                // One room can have multiple bookings
                entity.HasOne(b => b.Room)
                    .WithMany()
                    .HasForeignKey(b => b.RoomId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Staff configuration
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(s => s.StaffId);

                entity.Property(s => s.StaffName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(s => s.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(s => s.Salary)
                    .IsRequired()
                    .HasPrecision(10, 2);
            });

            // AuditLog configuration
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(a => a.AuditLogId);

                entity.Property(a => a.Action)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(a => a.TableName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(a => a.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(a => a.Time)
                    .IsRequired();
            });
        }

        // Automatically create audit log entries
        private void AddAuditLogs()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(entry =>
                    entry.Entity is not AuditLog &&
                    (entry.State == EntityState.Added ||
                     entry.State == EntityState.Modified ||
                     entry.State == EntityState.Deleted))
                .ToList();

            foreach (var entry in changedEntries)
            {
                string action = "";
                string description = "";

                string entityName =
                    entry.Entity.GetType().Name.ToLower();

                // Check INSERT, UPDATE and DELETE
                if (entry.State == EntityState.Added)
                {
                    action = "INSERT";
                    description = "New " + entityName + " added";
                }
                else if (entry.State == EntityState.Modified)
                {
                    action = "UPDATE";
                    description = entityName + " details updated";
                }
                else if (entry.State == EntityState.Deleted)
                {
                    action = "DELETE";
                    description = entityName + " record deleted";
                }

                string tableName =
                    entry.Metadata.GetTableName()
                    ?? entry.Entity.GetType().Name;

                // Add audit record
                AuditLogs.Add(new AuditLog
                {
                    Action = action,
                    TableName = tableName,
                    Description = description,
                    Time = DateTime.Now
                });
            }
        }

        // Asynchronous SaveChanges
        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            // Create audit records
            AddAuditLogs();

            // Save original data and audit records together
            return await base.SaveChangesAsync(
                acceptAllChangesOnSuccess,
                cancellationToken);
        }
    }
}
