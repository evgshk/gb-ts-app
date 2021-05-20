namespace Timesheets.Models.Dto
{
    /// <summary> Информация об аутентификации пользователя </summary>
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long ExpiresIn { get; set; }
    }
}