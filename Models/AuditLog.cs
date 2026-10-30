using System;

namespace HotelManagementSystem.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public string Action { get; set; }

        public string TableName { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        // Default constructor
        public AuditLog()
        {
            Action = "";
            TableName = "";
            Description = "";
            Time = DateTime.Now;
        }

        // Parameterized constructor
        public AuditLog(int auditLogId, string action,
            string tableName, string description, DateTime time)
        {
            AuditLogId = auditLogId;
            Action = action;
            TableName = tableName;
            Description = description;
            Time = time;
        }
    }
}