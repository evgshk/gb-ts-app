using System;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class SheetManager: ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public Sheet GetItem(Guid id)
        {
            return _sheetRepo.GetItem(id);
        }

        public Guid Create(SheetCreateRequest sheetRequest)
        {
            var sheet = new Sheet()
            {
                Id = Guid.NewGuid(),
                Amount = sheetRequest.Amount,
                ContractId = sheetRequest.ContractId,
                Date = sheetRequest.Date,
                EmployeeId = sheetRequest.EmployeeId,
                ServiceId = sheetRequest.ServiceId
            };
            
            _sheetRepo.Add(sheet);
            
            return sheet.Id;
        }
    }
}