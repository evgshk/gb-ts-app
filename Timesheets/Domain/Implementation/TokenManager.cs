using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Domain.Implementation
{
    public class TokenManager : ITokenManager
    {
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        private readonly JwtAccessOptions _jwtAccessOptions;
        private readonly JwtRefreshOptions _jwtRefreshOption;
        private readonly JwtSecurityTokenHandler _securityHandler = new JwtSecurityTokenHandler();

        public TokenManager(IRefreshTokenRepo refreshTokenRepo, IOptions<JwtAccessOptions> jwtAccessOptions, IOptions<JwtRefreshOptions> jwtRefreshOption)
        {
            _refreshTokenRepo = refreshTokenRepo;
            _jwtAccessOptions = jwtAccessOptions.Value;
            _jwtRefreshOption = jwtRefreshOption.Value;
        }

        public AccessTokenDto CreateAccessToken(List<Claim> claims)
        {
            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims); 
            var accessToken = _securityHandler.WriteToken(accessTokenRaw);
            var accessTokenResponse = new AccessTokenDto
            {
                Token = accessToken,
                Expires = accessTokenRaw.ValidTo                
            };
            return accessTokenResponse;
        }
        public async Task<string> CreateRefreshToken(List<Claim> claims)
        {            
            var refreshTokenRaw = _jwtRefreshOption.GenerateToken(claims);
            var refreshToken = _securityHandler.WriteToken(refreshTokenRaw);
            var refreshTokenDB = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = refreshToken,
                Expires = refreshTokenRaw.ValidTo
            };
            await _refreshTokenRepo.AddToken(refreshTokenDB);
            return refreshToken;
        }

        public Guid DecryptionRefreshToken(RefreshToken token)
        {
            var decryption = _securityHandler.ReadJwtToken(token.Token);
            var userGuid = Guid.Parse(decryption.Payload.Sub);
            return userGuid;
        }

        public async Task DeleteRefreshToken(RefreshTokenRequest token)
        {
            await _refreshTokenRepo.DeleteToken(token);
        }

        public async Task<RefreshToken> RefreshTokenValide(RefreshTokenRequest token)
        {
            var result = await _refreshTokenRepo.SearchToken(token);
            if(result != null && !result.IsExpired)
            {
                return result;
            }
            else
            {
                return default;
            }
        }
    }
}
