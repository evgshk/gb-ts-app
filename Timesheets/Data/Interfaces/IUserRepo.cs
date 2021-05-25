using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo : IRepoBase<User>
    {
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
    }
}