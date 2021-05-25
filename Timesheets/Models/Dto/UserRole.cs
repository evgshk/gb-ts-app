using System;

namespace Timesheets.Models.Dto
{
    /// <summary> Информация о роли пользователя </summary>
    public class UserRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}