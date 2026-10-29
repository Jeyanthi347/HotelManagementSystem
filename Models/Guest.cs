using System;
using System.Collections.Generic;
using System.Text;


namespace HotelManagementSystem.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Default constructor
        public Guest()
        {
            GuestName = "";
            Email = "";
            Phone = "";
        }

        // Parameterized constructor
        public Guest(int guestId, string guestName, string email,
                     string phone)
        {
            GuestId = guestId;
            GuestName = guestName;
            Email = email;
            Phone = phone;
        }
    }
}
