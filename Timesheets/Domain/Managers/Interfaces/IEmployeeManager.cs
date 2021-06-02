using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetItems();
        Task<Guid> Create(EmployeeRequest employeeRequest);
        Task Update(Guid id, EmployeeRequest employeeRequest);
    }
}
