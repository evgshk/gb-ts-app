using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Timesheets.Domain.Implementation
{
    public class LoginManager: ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;
        private readonly JwtRefreshOptions _jwtRefreshOptions;
        private readonly IRefreshTokenWrapperRepo _refreshTokenRepo;

        public LoginManager(
            IOptions<JwtAccessOptions> jwtAccessOptions, 
            IOptions<JwtRefreshOptions> jwtRefreshOptions,
            IRefreshTokenWrapperRepo refreshTokenRepo)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
            _jwtRefreshOptions = jwtRefreshOptions.Value;
            _refreshTokenRepo = refreshTokenRepo;
        }

        public LoginResponse Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);
            var refreshToken = securityHandler.WriteToken(refreshTokenRaw);

            var loginResponse = new LoginResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime()
            };

            var refreshTokenWrapper = new RefreshTokenWrapper()
            {
                Id = new System.Guid(),
                UserId = user.Id,
                Token = refreshToken
            };

            _refreshTokenRepo.Add(refreshTokenWrapper);

            return loginResponse;
        }

        public async Task<RefreshTokenWrapper> GetRefreshToken(RefreshRequest request)
        {
            var token = await _refreshTokenRepo.GetItem(request.RefreshToken);
            if (token != null)
            {
                _refreshTokenRepo.Delete(token);
            }
            return token;
        }
    }
}