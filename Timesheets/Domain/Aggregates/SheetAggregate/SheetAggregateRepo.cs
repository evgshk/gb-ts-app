using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.Aggregates.SheetAggregate
{
    public class SheetAggregateRepo : ISheetAggregateRepo
    {
        public Task Add(SheetAggregate item)
        {
            throw new NotImplementedException();
        }

        public Task<SheetAggregate> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SheetAggregate>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Update(SheetAggregate item)
        {
            throw new NotImplementedException();
        }
    }
}
