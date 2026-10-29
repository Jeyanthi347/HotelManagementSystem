using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repositories
{
    public class StaffRepository(AppDbContext context)
    {
        public List<Staff> GetAll()
        {
            return context.Staff.ToList();
        }

        public Staff? GetById(int id)
        {
            return context.Staff.Find(id);
        }

        public void Add(Staff staff)
        {
            context.Staff.Add(staff);
            context.SaveChanges();
        }

        public void Update(Staff staff)
        {
            context.Staff.Update(staff);
            context.SaveChanges();
        }

        public void Delete(int id)
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