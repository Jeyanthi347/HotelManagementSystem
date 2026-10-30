using System;
using System.Collections.Generic;
using System.Text;


namespace HotelManagementSystem.Helpers
{
    public class DateRules
    {
        public async Task<bool> IsValidBookingDates(
            DateTime checkInDate,
            DateTime checkOutDate)
        {
            return checkOutDate.Date > checkInDate.Date;
        }

        public async Task<bool> IsCheckInDateValid(DateTime checkInDate)
        {
            return checkInDate.Date >= DateTime.Today;
        }
    }
}

