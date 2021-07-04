using System;
using System.Threading.Tasks;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IContractManager
    {
        Task<bool?> CheckContractIsActive(Guid id);
    }
}