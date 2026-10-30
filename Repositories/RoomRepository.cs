using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repositories
{
    public class RoomRepository(AppDbContext context)
    {
        public async Task<List<Room>> GetAll()
        {
            return await context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetById(int id)
        {
            return await context.Rooms.FindAsync(id);
        }

        public async Task Add(Room room)
        {
            context.Rooms.Add(room);
            await context.SaveChangesAsync();
        }

        public async Task Update(Room room)
        {
            context.Rooms.Update(room);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Room? room = await context.Rooms.FindAsync(id);

            if (room != null)
            {
                context.Rooms.Remove(room);
                await context.SaveChangesAsync();
            }
        }
    }
}
