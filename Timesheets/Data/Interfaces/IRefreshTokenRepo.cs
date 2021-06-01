using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Interfaces
{
    public interface IRefreshTokenRepo
    {
        Task AddToken(RefreshToken token);
        Task<RefreshToken> SearchToken(RefreshTokenRequest token);
        Task DeleteToken(RefreshTokenRequest oldToken);
    }
}
