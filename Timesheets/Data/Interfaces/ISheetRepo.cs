using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface ISheetRepo: IRepoBase<Sheet>
    {
        Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}