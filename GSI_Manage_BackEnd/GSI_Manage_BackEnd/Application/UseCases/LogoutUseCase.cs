using System.Threading.Tasks;

namespace GSI_Manage_BackEnd.Application.UseCases
{
    public class LogoutUseCase
    {
        public async Task ExecuteAsync()
        {
            // In a stateless JWT implementation, logout is handled on the client side
            // by removing the token. We could implement token blacklisting here if needed.
            await Task.CompletedTask;
        }
    }
}