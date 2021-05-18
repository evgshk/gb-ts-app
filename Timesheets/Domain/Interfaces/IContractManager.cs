using System;
using System.Threading.Tasks;

namespace Timesheets.Domain.Interfaces
{
    public interface IContractManager
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}