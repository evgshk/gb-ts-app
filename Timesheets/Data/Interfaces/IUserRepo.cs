using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
        Task CreateUser(User user);
        Task<User> SearchUserByGuid(Guid id);
    }
}