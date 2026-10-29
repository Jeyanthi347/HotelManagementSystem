using System;
using System.Collections.Generic;
using System.Text;



namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string BookingStatus { get; set; }

        // Navigation properties
        public Guest? Guest { get; set; }
        public Room? Room { get; set; }

        // Default constructor
        public Booking()
        {
            BookingStatus = "Booked";
        }

        // Parameterized constructor
        public Booking(int bookingId, int guestId, int roomId,
                       DateTime checkInDate, DateTime checkOutDate,
                       string bookingStatus)
        {
            BookingId = bookingId;
            GuestId = guestId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            BookingStatus = bookingStatus;
        }
    }
}
