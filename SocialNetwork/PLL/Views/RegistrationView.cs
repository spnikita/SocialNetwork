using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        private readonly UserService _userService;

        public RegistrationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите данные:");

            Console.Write("→ имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("→ фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("→ пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("→ почтовый адрес: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                _userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException ex)
            {
                AllertMessage.Show(ex.Message);
            }
            catch (Exception ex)
            {
                AllertMessage.Show(ex.Message);
            }
        }
    }
}
