using System;
using System.Collections.Generic;
using System.Text;

using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;

namespace HotelManagementSystem.Services
{
    public class StaffService(StaffRepository staffRepository)
    {
        public List<Staff> GetAllStaff()
        {
            return staffRepository.GetAll();
        }

        public Staff? GetStaffById(int id)
        {
            return staffRepository.GetById(id);
        }

        public void AddStaff(Staff staff)
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

            staffRepository.Add(staff);
        }

        public void UpdateStaff(Staff staff)
        {
            Staff? existingStaff = staffRepository.GetById(staff.StaffId);

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

            staffRepository.Update(staff);
        }

        public void DeleteStaff(int id)
        {
            Staff? staff = staffRepository.GetById(id);

            if (staff == null)
            {
                throw new ArgumentException("Staff member not found.");
            }

            staffRepository.Delete(id);
        }
    }
}