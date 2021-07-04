using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(Guid id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<Guid> Create(SheetRequest sheet);
        Task Update(Guid id, SheetRequest sheetRequest);
    }
}