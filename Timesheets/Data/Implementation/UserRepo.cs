using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly TimesheetDbContext _context;

        public UserRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return
                await _context.Users
                    .Where(x => x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }

        public async Task Add(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetItem(Guid id)
        {
            return
                await _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return
                await _context.Users.ToListAsync();
        }

        public async Task Update(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
