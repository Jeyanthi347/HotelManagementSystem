using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class BookingService(
        BookingRepository bookingRepository,
        GuestRepository guestRepository,
        RoomRepository roomRepository)
    {
        public async Task<List<Booking>> GetAllBookings()
        {
            return await bookingRepository.GetAll();
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            return await bookingRepository.GetById(id);
        }

        public async Task AddBooking(Booking booking)
        {
            Guest? guest = await guestRepository.GetById(booking.GuestId);

            if (guest == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            Room? room = await roomRepository.GetById(booking.RoomId);

            if (room == null)
            {
                throw new ArgumentException("Room not found.");
            }

            if (!room.IsAvailable)
            {
                throw new ArgumentException("Room is not available.");
            }

            if (booking.CheckOutDate.Date <= booking.CheckInDate.Date)
            {
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");
            }

            booking.BookingStatus = "Booked";

            await bookingRepository.Add(booking);

            room.IsAvailable = false;
            await roomRepository.Update(room);
        }

        public async Task UpdateBooking(Booking booking)
        {
            Booking? existingBooking =
                await bookingRepository.GetById(booking.BookingId);

            if (existingBooking == null)
            {
                throw new ArgumentException("Booking not found.");
            }

            if (booking.CheckOutDate.Date <= booking.CheckInDate.Date)
            {
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");
            }

            if (guestRepository.GetById(booking.GuestId) == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            if (roomRepository.GetById(booking.RoomId) == null)
            {
                throw new ArgumentException("Room not found.");
            }

            await bookingRepository.Update(booking);
        }

        public async Task DeleteBooking(int id)
        {
            Booking? booking = await bookingRepository.GetById(id);

            if (booking == null)
            {
                throw new ArgumentException("Booking not found.");
            }

            Room? room = await roomRepository.GetById(booking.RoomId);

            await bookingRepository.Delete(id);

            if (room != null)
            {
                room.IsAvailable = true;
                await roomRepository.Update(room);
            }
        }
    }
}