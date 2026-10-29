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
        public List<Booking> GetAll()
        {
            return context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefault(b => b.BookingId == id);
        }

        public void Add(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            context.Bookings.Update(booking);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Booking? booking = context.Bookings.Find(id);

            if (booking != null)
            {
                context.Bookings.Remove(booking);
                context.SaveChanges();
            }
        }
    }
}