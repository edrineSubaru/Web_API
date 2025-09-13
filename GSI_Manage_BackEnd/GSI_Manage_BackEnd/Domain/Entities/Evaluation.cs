using System;

namespace GSI_Manage_BackEnd.Domain.Entities
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string EvaluationType { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string Findings { get; set; }
        public string Recommendations { get; set; }
        public int? Score { get; set; }
        public Guid? EvaluatorId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Project Project { get; set; }
    }
}