using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Helpers
{
    public class DatabaseHelper(AppDbContext context)
    {
        public bool CheckConnection()
        {
            return context.Database.CanConnect();
        }

        public void DisplayConnectionStatus()
        {
            if (CheckConnection())
            {
                Console.WriteLine(
                    "Database connected successfully.");
            }
            else
            {
                Console.WriteLine(
                    "Database connection failed.");
            }
        }
    }
}
