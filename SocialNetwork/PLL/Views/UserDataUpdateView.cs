using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        private readonly UserService _userService;

        public UserDataUpdateView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Введите обновленные данные");

            Console.Write("→ имя: ");
            user.FirstName = Console.ReadLine();

            Console.Write("→ фамилия: ");
            user.LastName = Console.ReadLine();

            Console.Write("→ ссылка на фото: ");
            user.Photo = Console.ReadLine();

            Console.Write("→ любимый фильм: ");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("→ любимая книга: ");
            user.FavoriteBook = Console.ReadLine();

            _userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
