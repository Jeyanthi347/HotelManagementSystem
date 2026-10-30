using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
{
    public class StaffRepository(AppDbContext context)
    {
        public async Task<List<Staff>> GetAll()
        {
            return await context.Staff.ToListAsync();
        }

        public async Task<Staff?> GetById(int id)
        {
            return await context.Staff.FindAsync(id);
        }

        public async Task Add(Staff staff)
        {
            context.Staff.Add(staff);
            await context.SaveChangesAsync();
        }

        public async Task Update(Staff staff)
        {
            context.Staff.Update(staff);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Staff? staff = context.Staff.Find(id);

            if (staff != null)
            {
                context.Staff.Remove(staff);
                context.SaveChanges();
            }
        }
    }
}