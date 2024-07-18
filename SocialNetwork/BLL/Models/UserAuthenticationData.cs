namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// Данные авторизации
    /// </summary>
    public class UserAuthenticationData
    {
        /// <summary>
        /// Почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }
    }
}
