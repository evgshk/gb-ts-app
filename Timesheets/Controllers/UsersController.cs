using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class UsersController : TimesheetsBaseController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary> Создает нового пользователя </summary>
        /// <returns> id нового пользователя </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest user)
        {
            var id = await _userManager.Create(user);
            return Ok(id);
        }

        /// <summary> Возвращает пользователя по id </summary>
        /// <returns> Пользователь </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _userManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает список пользователей </summary>
        /// <returns> Список пользователей </returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

        /// <summary> Изменяет User с заданным id </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] Guid id, [FromBody] UserRequest userRequest)
        {
            await _userManager.Update(id, userRequest);
            return;
        }
    }
}