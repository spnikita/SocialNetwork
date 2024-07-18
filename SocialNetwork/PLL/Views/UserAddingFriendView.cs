using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserAddingFriendView
    {
        /// <summary>
        /// Сервис работы с пользователями
        /// </summary>
        private readonly UserService _userService;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="userService"><inheritdoc cref="_userService" path="/summary"/></param>
        public UserAddingFriendView(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Показать меню добавления друзей
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        public void Show(User user)
        {
            var userAddingFriendData = new UserAddingFriendData();

            userAddingFriendData.CurrentUserId = user.Id;

            Console.Write("Введите почтовый адрес пользователя, которого хотите добавить в друзья: ");
            userAddingFriendData.FriendEmail = Console.ReadLine();

            try
            {
                _userService.AddFriend(userAddingFriendData);

                SuccessMessage.Show($"Пользователь {userAddingFriendData.FriendEmail} добавлен в друзья!");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь с указанным email существует.");
            }
            catch (ArgumentNullException)
            {
                AllertMessage.Show("Передан пустой почтовый адрес пользователя, которого необходимо добавить в друзья.");
            }
            catch (Exception)
            {
                AllertMessage.Show($"Ошибка добавления пользователя в друзья.");
            }
        }
    }
}
