using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repositories
{
    public class GuestRepository(AppDbContext context)
    {
        public async Task<List<Guest>> GetAll()
        {
            return await context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(int id)
        {
            return await context.Guests.FindAsync(id);
        }

        public async Task Add(Guest guest)
        {
            context.Guests.Add(guest);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guest guest)
        {
            context.Guests.Update(guest);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Guest? guest = await context.Guests.FindAsync(id);

            if (guest != null)
            {
                context.Guests.Remove(guest);
                await context.SaveChangesAsync();
            }
        }
    }
}
