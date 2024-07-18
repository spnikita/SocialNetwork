using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Определяет методы работы с таблицей БД Users
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Добавить запись в таблицу
        /// </summary>
        /// <param name="userEntity">Сущность (пользователь)</param>
        /// <returns>Результат выполнения команды</returns>
        int Create(UserEntity userEntity);

        /// <summary>
        /// Найти пользователя по e-mail
        /// </summary>
        /// <param name="email">E-mail</param>
        /// <returns>Пользователь</returns>
        UserEntity? FindByEmail(string email);

        /// <summary>
        /// Получить все записи таблицы Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntity> FindAll();

        /// <summary>
        /// Найти пользователя по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Пользователь</returns>
        UserEntity? FindById(int id);

        /// <summary>
        /// Обновить запись о пользователе в таблице БД Users
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns>Результат выполнения команды</returns>
        int Update(UserEntity userEntity);

        /// <summary>
        /// Удалить запись о пользователе в таблице БД Users по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Результат выполнения команды</returns>
        int DeleteById(int id);
    }
}
