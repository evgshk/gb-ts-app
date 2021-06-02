using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public interface IInvoiceAggregateRepo : IRepoBase<InvoiceAggregate>
    {
        Task<IEnumerable<SheetAggregate.SheetAggregate>> GetSheets(
            Guid contractId,
            DateTime dateStart, 
            DateTime dateEnd);
    }
}
