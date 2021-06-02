using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest invoiceRequest);
    }
}