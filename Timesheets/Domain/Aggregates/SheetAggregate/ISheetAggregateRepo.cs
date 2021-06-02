using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;

namespace Timesheets.Domain.Aggregates.SheetAggregate
{
    public interface ISheetAggregateRepo : IRepoBase<SheetAggregate>
    {
    }
}
