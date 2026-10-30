using System;
using System.Collections.Generic;
using System.Text;


using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Menus
{
    public class StaffMenu(StaffService staffService)
    {
        public async Task Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- STAFF MANAGEMENT ---");
                Console.WriteLine("1. View All Staff");
                Console.WriteLine("2. Add Staff");
                Console.WriteLine("3. Update Staff");
                Console.WriteLine("4. Delete Staff");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            await ViewStaff();
                            break;
                        case "2":
                            await AddStaff();
                            break;
                        case "3":
                            await UpdateStaff();
                            break;
                        case "4":
                            await DeleteStaff();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private async Task ViewStaff()
        {
            List<Staff> staffMembers = await staffService.GetAllStaff();

            if (staffMembers.Count == 0)
            {
                Console.WriteLine("No staff found.");
                return;
            }

            foreach (Staff staff in staffMembers)
            {
                Console.WriteLine(
                    $"ID: {staff.StaffId}, Name: {staff.StaffName}, " +
                    $"Role: {staff.Role}, Phone: {staff.Phone}, " +
                    $"Salary: {staff.Salary}");
            }
        }

        private async Task AddStaff()
        {
            Staff staff = new Staff();

            Console.Write("Enter staff name: ");
            staff.StaffName = Console.ReadLine() ?? "";

            Console.Write("Enter role: ");
            staff.Role = Console.ReadLine() ?? "";

            Console.Write("Enter phone: ");
            staff.Phone = Console.ReadLine() ?? "";

            Console.Write("Enter salary: ");
            staff.Salary = decimal.Parse(Console.ReadLine() ?? "0");

            await staffService.AddStaff(staff);
            Console.WriteLine("Staff added successfully.");
        }

        private async Task UpdateStaff()
        {
            Console.Write("Enter staff ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Staff? staff = await staffService.GetStaffById(id);

            if (staff == null)
            {
                Console.WriteLine("Staff member not found.");
                return;
            }

            Console.Write("Enter new staff name: ");
            staff.StaffName = Console.ReadLine() ?? "";

            Console.Write("Enter new role: ");
            staff.Role = Console.ReadLine() ?? "";

            Console.Write("Enter new phone: ");
            staff.Phone = Console.ReadLine() ?? "";

            Console.Write("Enter new salary: ");
            staff.Salary = decimal.Parse(Console.ReadLine() ?? "0");

            await staffService.UpdateStaff(staff);
            Console.WriteLine("Staff updated successfully.");
        }

        private async Task DeleteStaff()
        {
            Console.Write("Enter staff ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            await staffService.DeleteStaff(id);
            Console.WriteLine("Staff deleted successfully.");
        }
    }
}
