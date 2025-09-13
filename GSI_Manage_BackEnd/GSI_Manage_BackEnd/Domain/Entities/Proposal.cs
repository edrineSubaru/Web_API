using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Proposal
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public decimal? Value { get; set; }
        public string Status { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public Guid? LeadId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}