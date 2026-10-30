using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repositories
{
    public class BookingRepository(AppDbContext context)
    {
        public async Task<List<Booking>> GetAll()
        {
            return await context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .ToListAsync();
        }

        public async Task<Booking?> GetById(int id)
        {
            return await context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task Add(Booking booking)
        {
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        public async Task Update(Booking booking)
        {
            context.Bookings.Update(booking);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Booking? booking = await context.Bookings.FindAsync(id);

            if (booking != null)
            {
                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();
            }
        }
    }
}