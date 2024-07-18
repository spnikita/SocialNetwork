using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserOutgoingMessageView
    {
        public void Show(User user)
        {
            user.OutgoingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("От кого: {0}. Текст сообщения: {1}", message.SenderUserEmail, message.Content);
            });
        }
    }
}
