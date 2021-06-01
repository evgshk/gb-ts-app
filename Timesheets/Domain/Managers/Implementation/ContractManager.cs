using System;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;

namespace Timesheets.Domain.Managers.Implementation
{
    public class ContractManager: IContractManager
    {
        private readonly IContractRepo _contractRepo;

        public ContractManager(IContractRepo contractRepo)
        {
            _contractRepo = contractRepo;
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            return await _contractRepo.CheckContractIsActive(id);
        }
    }
}