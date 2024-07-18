using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        private readonly IUserRepository _userRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int userId)
        {
            var messages = new List<Message>();

            _messageRepository.FindByRecipientId(userId).ToList().ForEach(message =>
            {
                var senderUserEntity = _userRepository.FindById(message.sender_id);

                var recipientUserEntity = _userRepository.FindById(message.recipient_id);

                messages.Add(new Message(message.id, message.content, senderUserEntity!.email, recipientUserEntity!.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutgoingMessagesByUserId(int userId)
        {
            var messages = new List<Message>();

            _messageRepository.FindBySenderId(userId).ToList().ForEach(message =>
            {
                var senderUserEntity = _userRepository.FindById(message.sender_id);

                var recipientUserEntity = _userRepository.FindById(message.recipient_id);

                messages.Add(new Message(message.id, message.content, senderUserEntity!.email, recipientUserEntity!.email));
            });

            return messages;
        }

        public void SendMessage(MessageSendingData message)
        {
            if (string.IsNullOrEmpty(message.RecipientEmail))
                throw new ArgumentNullException("Отсутствует почтовый адрес получателя письма!");

            if (string.IsNullOrEmpty(message.Content))
                throw new ArgumentNullException("Отсутствует тело письма!");

            if (message.Content.Length > 5000)
                throw new ArgumentOutOfRangeException("Превышено допустимое число символов в сообщении!");

            var recipientUserEntity = _userRepository.FindByEmail(message.RecipientEmail) ?? throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = message.Content,
                sender_id = message.SenderId,
                recipient_id = recipientUserEntity.id
            };

            if (_messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
    }
}
