using System;

namespace Timesheets.Models
{
    /// <summary> Информация о владельце контракта </summary>
    public class Client
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}