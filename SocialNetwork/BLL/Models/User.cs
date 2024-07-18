namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; }

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

        /// <summary>
        /// Фотография
        /// </summary>
        public string? Photo { get; set; }

        /// <summary>
        /// Любимый фильм
        /// </summary>
        public string? FavoriteMovie { get; set; }

        /// <summary>
        /// Любимая книга
        /// </summary>
        public string? FavoriteBook { get; set; }

        /// <summary>
        /// Список входящих сообщений
        /// </summary>
        public IEnumerable<Message> IncomingMessages { get; }

        /// <summary>
        /// Список исходящих сообщений
        /// </summary>
        public IEnumerable<Message> OutgoingMessages { get; }

        /// <summary>
        /// Список друзей
        /// </summary>
        public IEnumerable<User> Friends { get; }

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
        /// <param name="firstName"><inheritdoc cref="FirstName" path="/summary"/></param>
        /// <param name="lastName"><inheritdoc cref="LastName" path="/summary"/></param>
        /// <param name="password"><inheritdoc cref="Password" path="/summary"/></param>
        /// <param name="email"><inheritdoc cref="Email" path="/summary"/></param>
        /// <param name="photo"><inheritdoc cref="Photo" path="/summary"/></param>
        /// <param name="favoriteMovie"><inheritdoc cref="FavoriteMovie" path="/summary"/></param>
        /// <param name="favoriteBook"><inheritdoc cref="FavoriteBook" path="/summary"/></param>
        /// <param name="incomingMessages"><inheritdoc cref="IncomingMessages" path="/summary"/></param>
        /// <param name="outgoingMessages"><inheritdoc cref="OutgoingMessages" path="/summary"/></param>
        /// <param name="friends"><inheritdoc cref="Friends" path="/summary"/></param>
        public User(
            int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,
            IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages,
            IEnumerable<User> friends)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
            IncomingMessages = incomingMessages;
            OutgoingMessages = outgoingMessages;
            Friends = friends;
        }
    }
}
