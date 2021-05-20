using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly TimesheetDbContext _context;

        public EmployeeRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            var result = await _context.Employees.ToListAsync();
            var filteredResult = result.Where(employee => employee.IsDeleted != true);

            return filteredResult.AsEnumerable();
        }

        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}