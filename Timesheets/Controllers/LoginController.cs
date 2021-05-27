using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;

        public LoginController(
            ILoginManager loginManager, 
            IUserManager userManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
        }

        /// <summary> Авторизация пользователя </summary>
        /// <param name="request"></param>
        /// <returns> LoginResponse </returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUser(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResponse = _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }

        /// <summary> Обновление токена </summary>
        /// <param name="request"></param>
        /// <returns> LoginResponse </returns>
        [HttpPost]
        public async Task<IActionResult> Reftesh([FromBody] RefreshRequest request)
        {
            var token = await _loginManager.Refresh(request);

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