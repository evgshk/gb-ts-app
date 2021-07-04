using System;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Implementation
{
    public class InvoiceManager: IInvoiceManager
    {
        private readonly IInvoiceRepo _invoiceRepo;
        //private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;

        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
            //_sheetRepo = sheetRepo;
        }

        public async Task<Guid> Create(InvoiceRequest request)
        {
            var invoice = InvoiceAggregate.Create(request.ContractId, request.DateEnd, request.DateStart);

            var sheetsToInclude = await _invoiceAggregateRepo
                .GetSheets(request.ContractId, request.DateStart, request.DateEnd);
            
            invoice.IncludeSheets(sheetsToInclude);
            await _invoiceRepo.Add(invoice);

            return invoice.Id;
        }
    }
}