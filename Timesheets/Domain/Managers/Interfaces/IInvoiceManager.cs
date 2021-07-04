using System;
using System.Threading.Tasks;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest request);
    }
}