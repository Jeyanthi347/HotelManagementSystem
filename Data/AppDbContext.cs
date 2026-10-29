using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Database tables
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Staff> Staff { get; set; }

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
        }
    }
}
