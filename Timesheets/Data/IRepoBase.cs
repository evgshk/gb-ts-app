using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.Data
{
    public interface IRepoBase<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems();
        Task Add(T item);
        Task Update(T item);
    }
}