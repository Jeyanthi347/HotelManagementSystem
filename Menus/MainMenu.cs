using System;
using System.Collections.Generic;
using System.Text;


namespace HotelManagementSystem.Menus
{
    public class MainMenu(
        RoomMenu roomMenu,
        GuestMenu guestMenu,
        BookingMenu bookingMenu,
        StaffMenu staffMenu)
    {
        public async Task Run()
        {
            while (true)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("    HOTEL MANAGEMENT SYSTEM");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Room Management");
                Console.WriteLine("2. Guest Management");
                Console.WriteLine("3. Booking Management");
                Console.WriteLine("4. Staff Management");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        await roomMenu.Show();
                        break;
                    case "2":
                        await guestMenu.Show();
                        break;
                    case "3":
                        await bookingMenu.Show();
                        break;
                    case "4":
                        await staffMenu.Show();
                        break;
                    case "0":
                        Console.WriteLine("Thank you for using the system.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
