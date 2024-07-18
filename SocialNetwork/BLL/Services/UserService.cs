using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Репозиторий для таблицы пользователей
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Репозиторий для таблицы друзей
        /// </summary>
        private readonly IFriendRepository _friendRepository;

        /// <summary>
        /// Репозиторий для таблицы сообщений
        /// </summary>
        private readonly MessageService _messageService;

        public UserService(IUserRepository userRepository, IFriendRepository friendRepository)
        {
            _userRepository = userRepository;
            _messageService = new MessageService();
            _friendRepository = friendRepository;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="data">Данные пользователя</param>
        /// <exception cref="ArgumentNullException">Введены некорректные данные для регистрации</exception>
        /// <exception cref="Exception">Ошибка регистрации пользователя</exception>
        public void Register(UserRegistrationData data)
        {
            if (string.IsNullOrEmpty(data.FirstName))
                throw new ArgumentNullException("Имя содержит пустое значение");

            if (string.IsNullOrEmpty(data.LastName))
                throw new ArgumentNullException("Фамилия содержит пустое значение");

            if (string.IsNullOrEmpty(data.Password))
                throw new ArgumentNullException("Пароль содержит пустое значение");

            if (data.Password.Length < 8)
                throw new ArgumentNullException("Длина пароля меньше 8 символов.");

            if (string.IsNullOrEmpty(data.Email))
                throw new ArgumentNullException("Почта содержит пустое значение");

            var emailAddressAttribute = new EmailAddressAttribute();
            if (!emailAddressAttribute.IsValid(data.Email))
                throw new ArgumentNullException("Почта указана некорректно.");

            if (_userRepository.FindByEmail(data.Email) != null)
                throw new ArgumentNullException($"Пользователь с Email = '{data.Email}' уже существует.");

            var user = new UserEntity()
            {
                firstname = data.FirstName,
                lastname = data.LastName,
                password = data.Password,
                email = data.Email
            };

            if (_userRepository.Create(user) == default)
                throw new Exception("Ошибка добавления пользователя в БД");
        }

        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <param name="data">Данные авторизации</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public User Authenticate(UserAuthenticationData data)
        {
            if (string.IsNullOrEmpty(data.Email) || string.IsNullOrEmpty(data.Password))
                throw new ArgumentNullException();

            var findUserEntity = _userRepository.FindByEmail(data.Email);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            if (findUserEntity.password != data.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Найти пользователя по Email
        /// </summary>
        /// <param name="email">Почтовый адрес</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        public User FindByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Передано пустое значение почтового адреса.");

            var findUserEntity = _userRepository.FindByEmail(email);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Найти пользователя по Id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        private User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);
            if (findUserEntity is null)
                throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <exception cref="Exception"></exception>
        public void Update(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
                throw new ArgumentNullException("Имя содержит пустое значение");

            if (string.IsNullOrEmpty(user.LastName))
                throw new ArgumentNullException("Фамилия содержит пустое значение");           

            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password!,
                email = user.Email!,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (_userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Добавить друша
        /// </summary>
        /// <param name="data">Данные друга для добавления</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void AddFriend(UserAddingFriendData data)
        {
            if (string.IsNullOrEmpty(data.FriendEmail))
                throw new ArgumentNullException();

            var userEntity = _userRepository.FindByEmail(data.FriendEmail) ?? throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = data.CurrentUserId,
                friend_id = userEntity.id
            };

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public void RefreshUserData(ref User user)
        {
            user = FindByEmail(user.Email!);
        }

        /// <summary>
        /// Создать модель пользователя
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = _messageService.GetIncomingMessagesByUserId(userEntity.id);

            var outgoingMessages = _messageService.GetOutgoingMessagesByUserId(userEntity.id);

            var friends = _friendRepository.FindAllByUserId(userEntity.id).Select(friend => FindById(friend.friend_id));

            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo!,
                          userEntity.favorite_movie!,
                          userEntity.favorite_book!,
                          incomingMessages,
                          outgoingMessages,
                          friends);
        }
    }
}
