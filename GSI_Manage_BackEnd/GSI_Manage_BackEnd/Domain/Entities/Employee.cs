using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public string Status { get; set; }
        public Guid? ManagerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual User Manager { get; set; }
        public virtual ICollection<Task> AssignedTasks { get; set; }
        public virtual ICollection<PayrollRecord> PayrollRecords { get; set; }
        public virtual ICollection<Asset> AssignedAssets { get; set; }
    }
}