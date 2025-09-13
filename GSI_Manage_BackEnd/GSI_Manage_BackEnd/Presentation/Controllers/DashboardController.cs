using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GSI_Manage_BackEnd.Application.DTOs;
using GSI_Manage_BackEnd.Application.UseCases;

namespace GSI_Manage_BackEnd.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly GetDashboardStatsUseCase _getDashboardStatsUseCase;

        public DashboardController(GetDashboardStatsUseCase getDashboardStatsUseCase)
        {
            _getDashboardStatsUseCase = getDashboardStatsUseCase;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var stats = await _getDashboardStatsUseCase.ExecuteAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching dashboard stats", error = ex.Message });
            }
        }
    }
}