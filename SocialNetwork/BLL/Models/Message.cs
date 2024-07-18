namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        public int Id { get; }

        public string Content { get; }

        public string SenderUserEmail { get; }

        public string RecipientUserEmail { get; }

        public Message(int id, string content, string senderUserEmail, string recipientUserEmail)
        {
            Id = id;
            Content = content;
            SenderUserEmail = senderUserEmail;
            RecipientUserEmail = recipientUserEmail;
        }
    }
}
