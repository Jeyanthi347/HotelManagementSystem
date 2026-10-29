using System;
using System.Collections.Generic;
using System.Text;


namespace HotelManagementSystem.Helpers
{
    public class HotelSettings
    {
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public HotelSettings()
        {
            HotelName = "Hotel Management System";
            Address = "";
            Phone = "";
        }

        public HotelSettings(
            string hotelName,
            string address,
            string phone)
        {
            HotelName = hotelName;
            Address = address;
            Phone = phone;
        }

        public void DisplaySettings()
        {
            Console.WriteLine("Hotel Name: " + HotelName);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Phone: " + Phone);
        }
    }
}
