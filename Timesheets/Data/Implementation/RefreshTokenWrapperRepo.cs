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
    public class RefreshTokenWrapperRepo : IRefreshTokenWrapperRepo
    {
        private readonly TimesheetDbContext _context;

        public RefreshTokenWrapperRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(RefreshTokenWrapper item)
        {
            await _context.RefreshTokenWrappers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public void Delete(RefreshTokenWrapper item)
        {
            _context.Remove(item);
        }

        public async Task<RefreshTokenWrapper> GetItem(string token)
        {
            return
                await _context.RefreshTokenWrappers
                    .Where(x => x.Token.Equals(token))
                    .FirstOrDefaultAsync();
        }

        public async Task Update(RefreshTokenWrapper item)
        {
            _context.RefreshTokenWrappers.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
