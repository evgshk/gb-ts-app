using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ITokenManager _tokenManager;


        public LoginController(ILoginManager loginManager, IUserManager userManager, ITokenManager tokenManager)
        {
            _loginManager = loginManager;
            _userManager = userManager;
            _tokenManager = tokenManager;
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
        
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var token = await _tokenManager.RefreshTokenValide(request);
            if(token == null)
            {
                return BadRequest();
            }
            var userGuid = _tokenManager.DecryptionRefreshToken(token);
            var user = await _userManager.SearchUserByGuid(userGuid);
            if(user == null)
            {
                return BadRequest();
            }
            var loginResponse = await _loginManager.Authenticate(user);
            return Ok(loginResponse);
        }
    }
}