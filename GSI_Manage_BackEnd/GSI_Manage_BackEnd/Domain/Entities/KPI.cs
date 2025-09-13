using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class KPI
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? CurrentValue { get; set; }
        public string Unit { get; set; }
        public string Period { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}