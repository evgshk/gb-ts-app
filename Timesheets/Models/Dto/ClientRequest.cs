using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    public class ClientRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
