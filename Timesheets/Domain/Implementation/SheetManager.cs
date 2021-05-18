using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }

        public async Task<Guid> Create(SheetRequest sheetRequest)
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
            
            await _sheetRepo.Add(sheet);
            
            return sheet.Id;
        }

        public async Task Update(Guid id, SheetRequest sheetRequest)
        {
            var sheet = new Sheet
            {
                Id = id,
                Amount = sheetRequest.Amount,
                ContractId = sheetRequest.ContractId,
                Date = sheetRequest.Date,
                EmployeeId = sheetRequest.EmployeeId,
                ServiceId = sheetRequest.ServiceId
            };
            
            await _sheetRepo.Update(sheet);
        }
    }
}