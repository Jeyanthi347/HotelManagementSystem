using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Menus
{
    public class GuestMenu(GuestService guestService)
    {
        public async Task Show()
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
                            await ViewGuests();
                            break;
                        case "2":
                            await AddGuest();
                            break;
                        case "3":
                            await UpdateGuest();
                            break;
                        case "4":
                            await DeleteGuest();
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

        private async Task ViewGuests()
        {
            List<Guest> guests = await guestService.GetAllGuests();

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

        private async Task AddGuest()
        {
            Guest guest = new Guest();

            Console.Write("Enter guest name: ");
            guest.GuestName = Console.ReadLine() ?? "";

            Console.Write("Enter email: ");
            guest.Email = Console.ReadLine() ?? "";

            Console.Write("Enter phone: ");
            guest.Phone = Console.ReadLine() ?? "";

            await guestService.AddGuest(guest);
            Console.WriteLine("Guest added successfully.");
        }

        private async Task UpdateGuest()
        {
            Console.Write("Enter guest ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Guest? guest = await guestService.GetGuestById(id);

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

             await guestService.UpdateGuest(guest);
            Console.WriteLine("Guest updated successfully.");
        }

        private async Task DeleteGuest()
        {
            Console.Write("Enter guest ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            await guestService.DeleteGuest(id);
            Console.WriteLine("Guest deleted successfully.");
        }
    }
}
