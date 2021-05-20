using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }

        public async Task<Guid> Create(UserRequest userRequest)
        {
            var user = new User()
            {
                Username = userRequest.Username
            };
            await _userRepo.Add(user);
            return user.Id;
        }

        public async Task Update(Guid id, UserRequest userRequest)
        {
            var user = new User()
            {
                Id = id,
                Username = userRequest.Username
            };

            await _userRepo.Update(user);
        }
    }
}