using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class RefreshController : TimesheetsBaseController
    {
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;

        public RefreshController(
            ILoginManager loginManager,
            IUserManager userManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
        }

        /// <summary> Обновление токена. Если токен из запроса найден в базе, он удаляется и повторяется процедура аутентификации </summary>
        /// <param name="request"></param>
        /// <returns> LoginResponse </returns>
        [HttpPost]
        public async Task<IActionResult> Reftesh([FromBody] RefreshRequest request)
        {
            var token = await _loginManager.GetRefreshToken(request);

            if (token == null)
            {
                return Unauthorized();
            }

            var user = await _userManager.GetItem(token.UserId);
            var loginResponse = _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }
    }
}
