using System;
using System.Collections.Generic;
using System.Text;


namespace HotelManagementSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

        // Default constructor
        public Staff()
        {
            StaffName = "";
            Role = "";
            Phone = "";
        }

        // Parameterized constructor
        public Staff(int staffId, string staffName, string role,
                     string phone, decimal salary)
        {
            StaffId = staffId;
            StaffName = staffName;
            Role = role;
            Phone = phone;
            Salary = salary;
        }
    }
}
