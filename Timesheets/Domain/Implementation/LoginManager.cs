using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class LoginManager: ILoginManager
    {

        private readonly ITokenManager _tokenManager;

        public LoginManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<LoginResponse> Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessToken = _tokenManager.CreateAccessToken(claims);
            var refreshToken =  await _tokenManager.CreateRefreshToken(claims);

            var loginResponse = new LoginResponse()
            {
                AccessToken = accessToken.Token,
                RefreshToken = refreshToken,
                AccessTokenExpiresIn = accessToken.Expires.ToEpochTime()
            };

            return loginResponse;
        }
    }
}