using System.Threading.Tasks;
using GSI_Manage_BackEnd.Application.DTOs;

namespace GSI_Manage_BackEnd.Application.Interfaces
{
    public interface IDashboardService
    {
        System.Threading.Tasks.Task<DashboardStatsDto> GetDashboardStatsAsync();
    }
}