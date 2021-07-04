using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
        Task CreateUser(User user);
    }
}