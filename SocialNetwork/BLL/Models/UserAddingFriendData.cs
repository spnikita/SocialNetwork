namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// Данные для добавления друга
    /// </summary>
    public class UserAddingFriendData
    {
        /// <summary>
        /// Идентификатор текушего пользователя
        /// </summary>
        public int CurrentUserId { get; set; }

        /// <summary>
        /// Почтовый адрес друга
        /// </summary>
        public string? FriendEmail { get; set; }
    }
}
