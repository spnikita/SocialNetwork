namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastname { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string? photo { get; set; }

        /// <summary>
        /// Любимый фильм
        /// </summary>
        public string? favorite_movie { get; set; }

        /// <summary>
        /// Любимая книга
        /// </summary>
        public string? favorite_book { get; set; }
    }
}
