using System.Threading.Tasks;
using GSI_Manage_BackEnd.Domain.Entities;

namespace GSI_Manage_BackEnd.Application.UseCases
{
    public class GetCurrentUserUseCase
    {
        public async System.Threading.Tasks.Task<User> ExecuteAsync()
        {
            // This would typically get the user from the current HTTP context
            // For now, return null as this requires additional setup
            return await System.Threading.Tasks.Task.FromResult<User>(null);
        }
    }
}