using System;

namespace Timesheets.Models.Entities
{
    /// <summary> Информация о владельце контракта </summary>
    public class Client
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public bool IsDeleted { get; set; }
    }
}