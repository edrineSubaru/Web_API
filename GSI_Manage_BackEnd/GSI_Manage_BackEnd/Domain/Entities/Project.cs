using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Budget { get; set; }
        public int Progress { get; set; }
        public Guid? ManagerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual User Manager { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}