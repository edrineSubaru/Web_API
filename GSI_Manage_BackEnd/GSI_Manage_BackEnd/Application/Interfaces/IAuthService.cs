using System.Threading.Tasks;
using GSI_Manage_BackEnd.Application.DTOs;
using GSI_Manage_BackEnd.Domain.Entities;

namespace GSI_Manage_BackEnd.Application.Interfaces
{
    public interface IAuthService
    {
        System.Threading.Tasks.Task<AuthResponse> LoginAsync(string email, string password);
        System.Threading.Tasks.Task<AuthResponse> RegisterAsync(RegisterRequest request);
        System.Threading.Tasks.Task LogoutAsync();
        System.Threading.Tasks.Task<User> GetCurrentUserAsync();
    }
}