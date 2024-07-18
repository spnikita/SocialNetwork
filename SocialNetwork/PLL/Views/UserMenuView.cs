using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        private readonly UserService _userService;

        public UserMenuView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                _userService.RefreshUserData(ref user);

                Console.WriteLine();
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
                Console.WriteLine("Мои друзья: {0}", user.Friends.Count());

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Посмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Посмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Посмотреть список друзей (нажмите 7)");
                Console.WriteLine("Выйти из профиля (нажмите 'x')");

                var key = Console.ReadLine();

                if (key == "x")
                    break;

                switch (key)
                {
                    case "1":
                        {
                            Program.UserInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.UserDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.UserAddingFriendView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.MessageSendingView.Show(user);
                            break;
                        }
                    case "5":
                        {
                            Program.UserIncomingMessageView.Show(user);
                            break;
                        }
                    case "6":
                        {
                            Program.UserOutgoingMessageView.Show(user);
                            break;
                        }
                    case "7":
                        {
                            Program.UserFriendsView.Show(user);
                            break;
                        }

                }
            }
        }
    }
}
