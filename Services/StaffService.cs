using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class StaffService(StaffRepository staffRepository)
    {
        public async Task<List<Staff>> GetAllStaff()
        {
            return await staffRepository.GetAll();
        }

        public async Task<Staff?> GetStaffById(int id)
        {
            return await staffRepository.GetById(id);
        }

        public async Task AddStaff(Staff staff)
        {
            if (string.IsNullOrWhiteSpace(staff.StaffName))
            {
                throw new ArgumentException("Staff name is required.");
            }

            if (string.IsNullOrWhiteSpace(staff.Role))
            {
                throw new ArgumentException("Staff role is required.");
            }

            if (staff.Salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }

               await staffRepository.Add(staff);
        }

        public async Task UpdateStaff(Staff staff)
        {
            Staff? existingStaff = await staffRepository.GetById(staff.StaffId);

            if (existingStaff == null)
            {
                throw new ArgumentException("Staff member not found.");
            }

            if (string.IsNullOrWhiteSpace(staff.StaffName) ||
                string.IsNullOrWhiteSpace(staff.Role))
            {
                throw new ArgumentException(
                    "Staff name and role are required.");
            }

            if (staff.Salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }

            await staffRepository.Update(staff);
        }

        public async Task DeleteStaff(int id)
        {
            Staff? staff = await staffRepository.GetById(id);

            if (staff == null)
            {
                throw new ArgumentException("Staff member not found.");
            }

            await staffRepository.Delete(id);
        }
    }
}