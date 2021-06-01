using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Timesheets.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
