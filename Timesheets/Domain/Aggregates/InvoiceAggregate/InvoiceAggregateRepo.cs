using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregateRepo : IInvoiceAggregateRepo
    {
        public Task Add(InvoiceAggregate item)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceAggregate> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceAggregate>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SheetAggregate.SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public Task Update(InvoiceAggregate item)
        {
            throw new NotImplementedException();
        }
    }
}
