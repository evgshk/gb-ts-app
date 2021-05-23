using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Создает пользователя 
        /// </summary>
        /// <returns> id созданного объекта </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest user)
        {
            var id = await _userManager.Create(user);
            return Ok(id);
        }

        /// <summary> Возвращает пользователя по id </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _userManager.GetItem(id);
            return Ok(result);
        }

        /// <summary> Возвращает список пользователей </summary>
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