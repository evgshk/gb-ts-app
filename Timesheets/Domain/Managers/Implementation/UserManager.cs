using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Guid> Create(UserRequest userRequest)
        {
            userRequest.EnsureNotNull(nameof(userRequest));
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userRequest.Username,
                PasswordHash = GetPasswordHash(userRequest.Password),
                Role = userRequest.Role
            };
            await _userRepo.Add(user);
            return user.Id;
        }

        public async Task<User> GetItem(Guid id)
        {
            return
                await _userRepo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return
                await _userRepo.GetItems();
        }

        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }

        public async Task Update(Guid id, UserRequest userRequest)
        {
            var user = new User
            {
                Id = id,
                Username = userRequest.Username
            };
            await _userRepo.Update(user);
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }

    }
}
