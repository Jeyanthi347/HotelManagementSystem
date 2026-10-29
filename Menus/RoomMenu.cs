using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Menus
{
    public class RoomMenu(RoomService roomService)
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- ROOM MANAGEMENT ---");
                Console.WriteLine("1. View All Rooms");
                Console.WriteLine("2. Add Room");
                Console.WriteLine("3. Update Room");
                Console.WriteLine("4. Delete Room");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ViewRooms();
                            break;
                        case "2":
                            AddRoom();
                            break;
                        case "3":
                            UpdateRoom();
                            break;
                        case "4":
                            DeleteRoom();
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

        private void ViewRooms()
        {
            List<Room> rooms = roomService.GetAllRooms();

            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms found.");
                return;
            }

            foreach (Room room in rooms)
            {
                Console.WriteLine(
                    $"ID: {room.RoomId}, Number: {room.RoomNumber}, " +
                    $"Type: {room.RoomType}, Price: {room.PricePerNight}, " +
                    $"Available: {room.IsAvailable}");
            }
        }

        private void AddRoom()
        {
            Room room = new Room();

            Console.Write("Enter room number: ");
            room.RoomNumber = Console.ReadLine() ?? "";

            Console.Write("Enter room type: ");
            room.RoomType = Console.ReadLine() ?? "";

            Console.Write("Enter price per night: ");
            room.PricePerNight = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Is room available? (true/false): ");
            room.IsAvailable = bool.Parse(Console.ReadLine() ?? "true");

            roomService.AddRoom(room);
            Console.WriteLine("Room added successfully.");
        }

        private void UpdateRoom()
        {
            Console.Write("Enter room ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Room? room = roomService.GetRoomById(id);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Console.Write("Enter new room number: ");
            room.RoomNumber = Console.ReadLine() ?? "";

            Console.Write("Enter new room type: ");
            room.RoomType = Console.ReadLine() ?? "";

            Console.Write("Enter new price per night: ");
            room.PricePerNight = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Is room available? (true/false): ");
            room.IsAvailable = bool.Parse(Console.ReadLine() ?? "true");

            roomService.UpdateRoom(room);
            Console.WriteLine("Room updated successfully.");
        }

        private void DeleteRoom()
        {
            Console.Write("Enter room ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            roomService.DeleteRoom(id);
            Console.WriteLine("Room deleted successfully.");
        }
    }
}
