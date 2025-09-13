using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Guid? ProjectId { get; set; }
        public DateTime Date { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User CreatedByUser { get; set; }
        public virtual Project Project { get; set; }
    }
}