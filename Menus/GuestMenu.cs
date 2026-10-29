using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Menus
{
    public class GuestMenu(GuestService guestService)
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- GUEST MANAGEMENT ---");
                Console.WriteLine("1. View All Guests");
                Console.WriteLine("2. Add Guest");
                Console.WriteLine("3. Update Guest");
                Console.WriteLine("4. Delete Guest");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ViewGuests();
                            break;
                        case "2":
                            AddGuest();
                            break;
                        case "3":
                            UpdateGuest();
                            break;
                        case "4":
                            DeleteGuest();
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

        private void ViewGuests()
        {
            List<Guest> guests = guestService.GetAllGuests();

            if (guests.Count == 0)
            {
                Console.WriteLine("No guests found.");
                return;
            }

            foreach (Guest guest in guests)
            {
                Console.WriteLine(
                    $"ID: {guest.GuestId}, Name: {guest.GuestName}, " +
                    $"Email: {guest.Email}, Phone: {guest.Phone}");
            }
        }

        private void AddGuest()
        {
            Guest guest = new Guest();

            Console.Write("Enter guest name: ");
            guest.GuestName = Console.ReadLine() ?? "";

            Console.Write("Enter email: ");
            guest.Email = Console.ReadLine() ?? "";

            Console.Write("Enter phone: ");
            guest.Phone = Console.ReadLine() ?? "";

            guestService.AddGuest(guest);
            Console.WriteLine("Guest added successfully.");
        }

        private void UpdateGuest()
        {
            Console.Write("Enter guest ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Guest? guest = guestService.GetGuestById(id);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            Console.Write("Enter new guest name: ");
            guest.GuestName = Console.ReadLine() ?? "";

            Console.Write("Enter new email: ");
            guest.Email = Console.ReadLine() ?? "";

            Console.Write("Enter new phone: ");
            guest.Phone = Console.ReadLine() ?? "";

            guestService.UpdateGuest(guest);
            Console.WriteLine("Guest updated successfully.");
        }

        private void DeleteGuest()
        {
            Console.Write("Enter guest ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            guestService.DeleteGuest(id);
            Console.WriteLine("Guest deleted successfully.");
        }
    }
}
