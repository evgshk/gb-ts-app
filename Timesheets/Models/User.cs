using System;

namespace Timesheets.Models
{
    /// <summary> Информация о пользователе системы </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}