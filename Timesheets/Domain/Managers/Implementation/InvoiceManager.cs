using System;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class InvoiceManager: IInvoiceManager
    {
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;
        private const int Rate = 100;

        public InvoiceManager(IInvoiceRepo invoiceRepo, IInvoiceAggregateRepo invoiceAggregateRepo)
        {
            _invoiceRepo = invoiceRepo;
            _invoiceAggregateRepo = invoiceAggregateRepo;
        }

        public async Task<Guid> Create(InvoiceRequest invoiceRequest)
        {
            var invoice = InvoiceAggregate.Create(
                invoiceRequest.ContractId, 
                invoiceRequest.DateStart, 
                invoiceRequest.DateEnd);
            
            var sheetsToInclude = await _invoiceAggregateRepo
                .GetSheets(invoiceRequest.ContractId, invoiceRequest.DateStart, invoiceRequest.DateEnd);

            invoice.IncludeSheets(sheetsToInclude);
            await _invoiceRepo.Add(invoice);

            return invoice.Id;
        }
    }
}