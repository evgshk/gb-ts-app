using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _EmployeeManager;

        public EmployeesController(IEmployeeManager EmployeeManager)
        {
            _EmployeeManager = EmployeeManager;
        }

        /// <summary> Создает работника, возвращает id /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest Employee)
        {
            var id = await _EmployeeManager.Create(Employee);
            return Ok(id);
        }

        /// <summary> Возвращает данные работника по id /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _EmployeeManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает список данных работников /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _EmployeeManager.GetItems();
            return Ok(result);
        }

        /// <summary> Изменяет данные работника с заданным id /// </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] Guid id, [FromBody] EmployeeRequest EmployeeRequest)
        {
            await _EmployeeManager.Update(id, EmployeeRequest);
            return;
        }
    }
}