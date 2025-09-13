using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class PayrollRecord
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Period { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
        public string Status { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }
    }
}