using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementation
{
    public class UserRepo: IUserRepo
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
                    .Where(x=> x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}