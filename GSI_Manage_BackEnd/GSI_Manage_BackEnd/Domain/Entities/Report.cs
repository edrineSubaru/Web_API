using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string Status { get; set; }
        public string FilePath { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User CreatedByUser { get; set; }
    }
}