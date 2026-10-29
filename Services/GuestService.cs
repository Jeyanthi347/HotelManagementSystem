using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class GuestService(GuestRepository guestRepository)
    {
        public List<Guest> GetAllGuests()
        {
            return guestRepository.GetAll();
        }

        public Guest? GetGuestById(int id)
        {
            return guestRepository.GetById(id);
        }

        public void AddGuest(Guest guest)
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

            guestRepository.Add(guest);
        }

        public void UpdateGuest(Guest guest)
        {
            Guest? existingGuest = guestRepository.GetById(guest.GuestId);

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

            guestRepository.Update(guest);
        }

        public void DeleteGuest(int id)
        {
            Guest? guest = guestRepository.GetById(id);

            if (guest == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            guestRepository.Delete(id);
        }
    }
}