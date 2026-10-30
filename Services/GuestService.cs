using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class GuestService(GuestRepository guestRepository)
    {
        public async Task<List<Guest>> GetAllGuests()
        {
            return await guestRepository.GetAll();
        }

        public async Task<Guest?> GetGuestById(int id)
        {
            return await guestRepository.GetById(id);
        }

        public async Task AddGuest(Guest guest)
        {
            if (string.IsNullOrWhiteSpace(guest.GuestName))
            {
                throw new ArgumentException("Guest name is required.");
            }

            if (string.IsNullOrWhiteSpace(guest.Email))
            {
                throw new ArgumentException("Guest email is required.");
            }

            if (string.IsNullOrWhiteSpace(guest.Phone))
            {
                throw new ArgumentException("Guest phone is required.");
            }

            await guestRepository.Add(guest);
        }

        public async Task UpdateGuest(Guest guest)
        {
            Guest? existingGuest = await guestRepository.GetById(guest.GuestId);

            if (existingGuest == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            if (string.IsNullOrWhiteSpace(guest.GuestName) ||
                string.IsNullOrWhiteSpace(guest.Email) ||
                string.IsNullOrWhiteSpace(guest.Phone))
            {
                throw new ArgumentException(
                    "Guest name, email and phone are required.");
            }

            await guestRepository.Update(guest);
        }

        public async Task DeleteGuest(int id)
        {
            Guest? guest = await guestRepository.GetById(id);

            if (guest == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            await guestRepository.Delete(id);
        }
    }
}