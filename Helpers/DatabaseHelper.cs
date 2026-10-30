using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Helpers
{
    public class DatabaseHelper(AppDbContext context)
    {
        public async Task<bool> CheckConnection()
        {
            return await context.Database.CanConnectAsync();
        }

        public async Task DisplayConnectionStatus()
        {
            if (await CheckConnection())
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
