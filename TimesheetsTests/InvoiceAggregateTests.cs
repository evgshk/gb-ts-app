using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Domain;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Models;
using Xunit;

namespace TimesheetsTests
{
    public class InvoiceAggregateTests
    {
        public Guid contractId = Guid.Parse("38e87365-5030-4ba5-b5bb-e3334c6cbc7f");

        [Fact]
        public void IncludeSheetsTest()
        {
            var invoiceBuilder = new InvoiceAggregateBuilder();
            int numOfSheets = 3;
            var sheetBuilder = new SheetAggregateBuilder();
            List<Sheet> TestSheets = new();
            for (int i = 0; i < numOfSheets; i++)
            {
                TestSheets.Add(sheetBuilder.CreateRandomSheet());
            }

            var invoiceAggregate = invoiceBuilder.GetRandomInvoiceAggregate();

            invoiceAggregate.IncludeSheets(TestSheets);

            Money sum = Money.FromDecimal(numOfSheets * sheetBuilder.amountForRandomSheets);
            invoiceAggregate.Sheets.Should().BeEquivalentTo(TestSheets);
            invoiceAggregate.Sum.Should().BeEquivalentTo(sum);
    }
}
}
