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
        public List<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Room? GetById(int id)
        {
            return context.Rooms.Find(id);
        }

        public void Add(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Update(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Room? room = context.Rooms.Find(id);

            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }
    }
}
