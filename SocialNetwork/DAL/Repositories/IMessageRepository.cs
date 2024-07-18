using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Определяет методы работы с таблицей БД Messages
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Добавить запись в таблицу
        /// </summary>
        /// <param name="messageEntity">Сущность (сообщение)</param>
        /// <returns>Результат выполнения команды</returns>
        int Create(MessageEntity messageEntity);

        /// <summary>
        /// Найти сообщение по id отправителя
        /// </summary>
        /// <param name="senderId">Id отправителя</param>
        /// <returns>Список сообщений</returns>
        IEnumerable<MessageEntity> FindBySenderId(int senderId);

        /// <summary>
        /// Найти сообщение по id получателя
        /// </summary>
        /// <param name="recipientId">Id получателя</param>
        /// <returns>Список сообщений</returns>
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);

        /// <summary>
        /// Удалить запись о сообщении в таблице БД Messages по id
        /// </summary>
        /// <param name="messageId">Id сообщения</param>
        /// <returns>Результат выполнения команды</returns>
        int DeleteById(int messageId);
    }
}
