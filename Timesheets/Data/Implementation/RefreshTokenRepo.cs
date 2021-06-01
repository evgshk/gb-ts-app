using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Implementation
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        private readonly TimesheetDbContext _dbContext;

        public RefreshTokenRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToken(RefreshToken token)
        {
            await _dbContext.Tokens.AddAsync(token);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RefreshToken> SearchToken(RefreshTokenRequest token)
        {
            var result = await _dbContext.Tokens.Where(t => t.Token == token.Token).FirstOrDefaultAsync();
            return result;
        }

        public async Task DeleteToken(RefreshTokenRequest oldToken)
        {
            var token = await SearchToken(oldToken);
            if(token != null)
            {
                _dbContext.Tokens.Remove(token);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
