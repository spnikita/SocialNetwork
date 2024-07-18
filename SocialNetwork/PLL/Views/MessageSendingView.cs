using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class MessageSendingView
    {
        private readonly UserService _userService;

        private readonly MessageService _messageService;

        public MessageSendingView(UserService userService, MessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public void Show(User user)
        {
            var message = new MessageSendingData();

            Console.Write("Введите почтовый адрес получателя: ");
            message.RecipientEmail = Console.ReadLine();

            Console.Write("Введите сообщение (не более 5000 символов): ");
            message.Content = Console.ReadLine();

            message.SenderId = user.Id;

            try
            {
                _messageService.SendMessage(message);

                SuccessMessage.Show("Сообщение успешно отправлено!");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException ex)
            {
                AllertMessage.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AllertMessage.Show(ex.Message);
            }
            catch (Exception ex)
            {
                AllertMessage.Show($"Произлшла ошибка обработки сообщения: {ex.Message}");
            }
        }
    }
}
