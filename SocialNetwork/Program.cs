using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    public class Program
    {
        private static readonly IUserRepository UserRepository = new UserRepository();

        private static readonly IFriendRepository FriendRepository = new FriendRepository();                

        private static readonly MessageService MessageService = new MessageService();

        private static readonly MainView MainView = new MainView();

        public static readonly UserInfoView UserInfoView = new UserInfoView();

        public static readonly UserIncomingMessageView UserIncomingMessageView = new UserIncomingMessageView();

        public static readonly UserOutgoingMessageView UserOutgoingMessageView = new UserOutgoingMessageView();

        public static readonly UserFriendsView UserFriendsView = new UserFriendsView();

        private static readonly UserService UserService;

        public static readonly RegistrationView RegistrationView;

        public static readonly AuthenticationView AuthenticationView;

        public static readonly UserMenuView UserMenuView;

        public static readonly UserDataUpdateView UserDataUpdateView;

        public static readonly MessageSendingView MessageSendingView;

        public static readonly UserAddingFriendView UserAddingFriendView;

        static Program()
        {
            UserService = new UserService(UserRepository, FriendRepository);
            RegistrationView = new RegistrationView(UserService);
            AuthenticationView = new AuthenticationView(UserService);
            UserMenuView = new UserMenuView(UserService);
            UserDataUpdateView = new UserDataUpdateView(UserService);
            MessageSendingView = new MessageSendingView(UserService, MessageService);
            UserAddingFriendView = new UserAddingFriendView(UserService);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");

            while (true)
            {
                MainView.Show();
            }
        }
    }
}
