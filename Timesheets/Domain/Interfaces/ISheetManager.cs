using System;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Sheet GetItem(Guid id);
        Guid Create(SheetCreateRequest sheet);
    }
}