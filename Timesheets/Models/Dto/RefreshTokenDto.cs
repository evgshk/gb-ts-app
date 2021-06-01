using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    public class RefreshTokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
