using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IRefreshTokenWrapperRepo 
    {
        Task Add(RefreshTokenWrapper item);
        Task<RefreshTokenWrapper> GetItem(string token);
        Task Update(RefreshTokenWrapper item);
        void Delete(RefreshTokenWrapper item);
    }
}
