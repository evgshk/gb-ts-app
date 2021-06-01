using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ITokenManager
    {
        AccessTokenDto CreateAccessToken(List<Claim> claims);
        Task<string> CreateRefreshToken(List<Claim> claims);
        Task<RefreshToken> RefreshTokenValide(RefreshTokenRequest token);
        Task DeleteRefreshToken(RefreshTokenRequest token);
        Guid DecryptionRefreshToken(RefreshToken token);
    }
}
