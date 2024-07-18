namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public int sender_id { get; set; }

        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public int recipient_id { get; set; }
    }
}
