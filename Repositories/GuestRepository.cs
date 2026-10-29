using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
{
    public class GuestRepository(AppDbContext context)
    {
        public List<Guest> GetAll()
        {
            return context.Guests.ToList();
        }

        public Guest? GetById(int id)
        {
            return context.Guests.Find(id);
        }

        public void Add(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
        }

        public void Update(Guest guest)
        {
            context.Guests.Update(guest);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Guest? guest = context.Guests.Find(id);

            if (guest != null)
            {
                context.Guests.Remove(guest);
                context.SaveChanges();
            }
        }
    }
}
