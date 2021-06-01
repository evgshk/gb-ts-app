using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementation
{
    public class InvoiceRepo: IInvoiceRepo
    {
        private readonly TimesheetDbContext _context;

        public InvoiceRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        
        public Task<Invoice> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task Add(Invoice item)
        {
            

            await _context.Invoices.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task Update(Invoice item)
        {
            throw new NotImplementedException();
        }
    }
}