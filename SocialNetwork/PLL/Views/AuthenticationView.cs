using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        private readonly UserService _userService;

        public AuthenticationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.Write("Введите почтовый адрес: ");
            authenticationData.Email = Console.ReadLine();

            Console.Write("Введите пароль: ");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = _userService.Authenticate(authenticationData);

                SuccessMessage.Show($"Вы успешно вошли в социальную сеть! Добро пожаловать, {user.FirstName}.");

                Program.UserMenuView.Show(user);
            }
            catch (ArgumentNullException)
            {
                AllertMessage.Show("Ввыедены пустые почтовый адрес или пароль.");
            }
            catch (WrongPasswordException)
            {
                AllertMessage.Show("Пароль не корректный!");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
