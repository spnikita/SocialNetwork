namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// Данные регистрации
    /// </summary>
    public class UserRegistrationData
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string? Email { get; set; }
    }
}
