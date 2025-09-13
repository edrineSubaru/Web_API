namespace GSI_Manage_BackEnd.Application.DTOs
{
    public class DashboardStatsDto
    {
        public int ActiveProjects { get; set; }
        public int TotalEmployees { get; set; }
        public int PendingTasks { get; set; }
        public decimal MonthlyRevenue { get; set; }
    }
}