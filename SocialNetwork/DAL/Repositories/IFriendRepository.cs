using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Определяет методы работы с таблицей БД Friends
    /// </summary>
    public interface IFriendRepository
    {
        /// <summary>
        /// Добавить запись в таблицу
        /// </summary>
        /// <param name="friendEntity">Сущность (друг)</param>
        /// <returns>Результат выполнения команды</returns>
        int Create(FriendEntity friendEntity);

        /// <summary>
        /// Найти всех друзей пользователя по его id
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>Список друзей</returns>
        IEnumerable<FriendEntity> FindAllByUserId(int userId);

        /// <summary>
        /// Удалить запись о сообщении в таблице БД Friends по id
        /// </summary>
        /// <param name="id">Id связки пользователь + друг</param>
        /// <returns>Результат выполнения команды</returns>
        int Delete(int id);
    }
}
