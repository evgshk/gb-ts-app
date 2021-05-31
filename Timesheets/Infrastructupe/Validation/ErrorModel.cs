using System.Collections.Generic;

namespace Timesheets.Infrastructure.Validation
{
    public class ErrorModel
    {
        public Dictionary<string, string> Errors { get; set; }
        public string Message { get; set; }
    }
}