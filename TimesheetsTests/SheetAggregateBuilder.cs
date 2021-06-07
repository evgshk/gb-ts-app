using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.SheetAggregate;
using Timesheets.Models.Dto;

namespace TimesheetsTests
{
    public class SheetAggregateBuilder
    {
        public Guid SheetContractId = Guid.Parse("27033e94-3fea-42a1-bedd-b00985c7ec9b");
        public Guid SheetEmployeeId = Guid.Parse("8d7fdafb-12ca-403a-bc6d-f45e13499bcb");
        public Guid SheetServiceId = Guid.Parse("38e87365-5030-4ba5-b5bb-e3334c6cbc7f");
        public int amountForRandomSheets = 7;

        public SheetAggregate CreateRandomSheet()
        {
            var sheetRequest = new SheetRequest()
            {
                Amount = amountForRandomSheets,
                ContractId = SheetContractId,
                Date = DateTime.Now,
                EmployeeId = SheetEmployeeId,
                ServiceId = SheetServiceId
            };

            var result = SheetAggregate.CreateFromRequest(sheetRequest);

            return result;
        }
    }
}
