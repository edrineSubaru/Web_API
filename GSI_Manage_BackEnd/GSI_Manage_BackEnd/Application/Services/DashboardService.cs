using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GSI_Manage_BackEnd.Application.DTOs;
using GSI_Manage_BackEnd.Application.Interfaces;
using GSI_Manage_BackEnd.Infrastructure.Data;

namespace GSI_Manage_BackEnd.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;

            var stats = new DashboardStatsDto
            {
                ActiveProjects = await _context.Projects.CountAsync(p => p.Status == "active"),
                TotalEmployees = await _context.Employees.CountAsync(e => e.Status == "active"),
                PendingTasks = await _context.Tasks.CountAsync(t => t.Status == "pending"),
                MonthlyRevenue = await _context.Transactions
                    .Where(t => t.Type == "income" &&
                               t.Date.Month == currentMonth &&
                               t.Date.Year == currentYear)
                    .SumAsync(t => t.Amount)
            };

            return stats;
        }
    }
}