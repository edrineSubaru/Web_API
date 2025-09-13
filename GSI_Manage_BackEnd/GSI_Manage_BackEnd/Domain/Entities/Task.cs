using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual Employee? Assignee { get; set; }
        public virtual Project? Project { get; set; }
        public virtual User? CreatedBy { get; set; }
    }
}