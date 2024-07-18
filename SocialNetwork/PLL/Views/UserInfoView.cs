using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("Информация о моем профиле:");
            Console.WriteLine("→ идентификатор: {0};", user.Id);
            Console.WriteLine("→ имя: {0};", user.FirstName);
            Console.WriteLine("→ фамилия: {0};", user.LastName);
            Console.WriteLine("→ пароль: {0};", user.Password);
            Console.WriteLine("→ почтовый адрес: {0};", user.Email);
            Console.WriteLine("→ ссылка на фото: {0};", user.Photo);
            Console.WriteLine("→ любимый фильм: {0};", user.FavoriteMovie);
            Console.WriteLine("→ любимая книга: {0}.", user.FavoriteBook);
        }
    }
}
