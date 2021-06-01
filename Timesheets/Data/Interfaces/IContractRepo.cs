using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IContractRepo: IRepoBase<Contract>
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}