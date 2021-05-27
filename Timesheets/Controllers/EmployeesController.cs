using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class EmployeesController : TimesheetsBaseController
    {
        private readonly IEmployeeManager _EmployeeManager;

        public EmployeesController(IEmployeeManager EmployeeManager)
        {
            _EmployeeManager = EmployeeManager;
        }

        /// <summary> Создает работника </summary>
        /// <returns> id работника </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest Employee)
        {
            var id = await _EmployeeManager.Create(Employee);
            return Ok(id);
        }

        /// <summary> Получает данные работника по id </summary>
        /// <returns> Данные работника </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _EmployeeManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Получает список данных работников </summary>
        /// <returns> Список данных работников </returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _EmployeeManager.GetItems();
            return Ok(result);
        }

        /// <summary> Изменяет данные работника с заданным id </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] Guid id, [FromBody] EmployeeRequest EmployeeRequest)
        {
            await _EmployeeManager.Update(id, EmployeeRequest);
            return;
        }
    }
}