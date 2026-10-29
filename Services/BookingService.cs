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
        public List<Booking> GetAllBookings()
        {
            return bookingRepository.GetAll();
        }

        public Booking? GetBookingById(int id)
        {
            return bookingRepository.GetById(id);
        }

        public void AddBooking(Booking booking)
        {
            Guest? guest = guestRepository.GetById(booking.GuestId);

            if (guest == null)
            {
                throw new ArgumentException("Guest not found.");
            }

            Room? room = roomRepository.GetById(booking.RoomId);

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

            bookingRepository.Add(booking);

            room.IsAvailable = false;
            roomRepository.Update(room);
        }

        public void UpdateBooking(Booking booking)
        {
            Booking? existingBooking =
                bookingRepository.GetById(booking.BookingId);

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

            bookingRepository.Update(booking);
        }

        public void DeleteBooking(int id)
        {
            Booking? booking = bookingRepository.GetById(id);

            if (booking == null)
            {
                throw new ArgumentException("Booking not found.");
            }

            Room? room = roomRepository.GetById(booking.RoomId);

            bookingRepository.Delete(id);

            if (room != null)
            {
                room.IsAvailable = true;
                roomRepository.Update(room);
            }
        }
    }
}