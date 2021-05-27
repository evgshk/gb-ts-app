using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ILoginManager
    {
        LoginResponse Authenticate(User user);
        Task<RefreshTokenWrapper> GetRefreshToken(RefreshRequest request);
    }
}