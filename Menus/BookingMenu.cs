using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Menus
{
    public class BookingMenu(BookingService bookingService)
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- BOOKING MANAGEMENT ---");
                Console.WriteLine("1. View All Bookings");
                Console.WriteLine("2. Add Booking");
                Console.WriteLine("3. Update Booking");
                Console.WriteLine("4. Delete Booking");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ViewBookings();
                            break;
                        case "2":
                            AddBooking();
                            break;
                        case "3":
                            UpdateBooking();
                            break;
                        case "4":
                            DeleteBooking();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void ViewBookings()
        {
            List<Booking> bookings = bookingService.GetAllBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            foreach (Booking booking in bookings)
            {
                Console.WriteLine(
                    $"Booking ID: {booking.BookingId}, " +
                    $"Guest ID: {booking.GuestId}, " +
                    $"Room ID: {booking.RoomId}, " +
                    $"Check-in: {booking.CheckInDate:yyyy-MM-dd}, " +
                    $"Check-out: {booking.CheckOutDate:yyyy-MM-dd}, " +
                    $"Status: {booking.BookingStatus}");
            }
        }

        private void AddBooking()
        {
            Booking booking = new Booking();

            Console.Write("Enter guest ID: ");
            booking.GuestId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter room ID: ");
            booking.RoomId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter check-in date (yyyy-MM-dd): ");
            booking.CheckInDate =
                DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Enter check-out date (yyyy-MM-dd): ");
            booking.CheckOutDate =
                DateTime.Parse(Console.ReadLine() ?? "");

            bookingService.AddBooking(booking);
            Console.WriteLine("Booking added successfully.");
        }

        private void UpdateBooking()
        {
            Console.Write("Enter booking ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Booking? booking = bookingService.GetBookingById(id);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            Console.Write("Enter new guest ID: ");
            booking.GuestId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter new room ID: ");
            booking.RoomId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter new check-in date (yyyy-MM-dd): ");
            booking.CheckInDate =
                DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Enter new check-out date (yyyy-MM-dd): ");
            booking.CheckOutDate =
                DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Enter booking status: ");
            booking.BookingStatus = Console.ReadLine() ?? "Booked";

            bookingService.UpdateBooking(booking);
            Console.WriteLine("Booking updated successfully.");
        }

        private void DeleteBooking()
        {
            Console.Write("Enter booking ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            bookingService.DeleteBooking(id);
            Console.WriteLine("Booking deleted successfully.");
        }
    }
}
