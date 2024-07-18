using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        public void Show(User user)
        {
            user.Friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Имя: {0}; Фамилия: {1}; Почтовый адрес: {2}", friend.FirstName, friend.LastName, friend.Email);
            });
        }
    }
}
