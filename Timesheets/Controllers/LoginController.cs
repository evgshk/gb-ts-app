using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager, IUserManager userManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUser(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResponse = await _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }

        public async Task<IActionResult> Refresh()
        {
            // return new (refresh, access);
            
            var rub100 = Money.FromDecimal(100);

            return null;
        }
    }
}