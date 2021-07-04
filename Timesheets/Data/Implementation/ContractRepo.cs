using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementation
{
    public class ContractRepo:IContractRepo
    {
        private readonly TimesheetDbContext _dbContext;

        public ContractRepo(TimesheetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Contract> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contract>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Add(Contract item)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Contract item)
        {
            _dbContext.Contracts.Update(item);
            await _dbContext.SaveChangesAsync();
        }
        

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract = await _dbContext.Contracts.FindAsync(id);
            var now = DateTime.Now;
            var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;

            return isActive;
        }
    }
}