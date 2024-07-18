namespace SocialNetwork.BLL.Models
{
    public class MessageSendingData
    {
        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Содержимое письма
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Почтовый адрес получателя
        /// </summary>
        public string? RecipientEmail { get; set; }
    }
}
