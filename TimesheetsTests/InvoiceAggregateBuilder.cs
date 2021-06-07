using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.InvoiceAggregate;

namespace TimesheetsTests
{
    public class InvoiceAggregateBuilder
    {
        private Guid contractId = Guid.Parse("38e87365-5030-4ba5-b5bb-e3334c6cbc7f");
        private int numOfDays = 30;

        public InvoiceAggregate GetRandomInvoiceAggregate()
        {
            var invoiceAggregate = InvoiceAggregate.Create(contractId, DateTime.Now, DateTime.Now.AddDays(numOfDays));
            return invoiceAggregate;
        }

    }
}
