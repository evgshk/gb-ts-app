using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResponse> Authenticate(User user);
    }
}