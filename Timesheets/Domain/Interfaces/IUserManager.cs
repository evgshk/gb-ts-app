using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Create(UserRequest userRequest);
        Task Update(Guid id, UserRequest userRequest);
    }
}
