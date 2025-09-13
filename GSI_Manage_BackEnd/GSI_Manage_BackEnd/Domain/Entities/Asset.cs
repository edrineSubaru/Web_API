using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchaseValue { get; set; }
        public decimal? CurrentValue { get; set; }
        public string Status { get; set; }
        public Guid? AssignedTo { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual Employee AssignedToEmployee { get; set; }
    }
}