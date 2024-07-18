namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// Друг
    /// </summary>
    public class FriendEntity
    {
        /// <summary>
        /// Идентификатор записи в таблице Friends
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// Идентификатор друга пользователя
        /// </summary>
        public int friend_id { get; set; }
    }
}
