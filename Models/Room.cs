using System;
using System.Collections.Generic;
using System.Text;



namespace HotelManagementSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        // Default constructor
        public Room()
        {
            RoomNumber = "";
            RoomType = "";
            IsAvailable = true;
        }

        // Parameterized constructor
        public Room(int roomId, string roomNumber, string roomType,
                    decimal pricePerNight, bool isAvailable)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }
    }
}

