using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Implementation;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeesController(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _employeeManager.GetItem(id);
            
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest employee)
        {
            var id = await _employeeManager.Create(employee);
            
            return Ok(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest employee)
        {
            await _employeeManager.Update(id, employee);
            return Ok();
        }
    }
}