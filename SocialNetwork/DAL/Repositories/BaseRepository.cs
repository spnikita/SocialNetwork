using System.Data.SQLite;
using System.Data;
using Dapper;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private const string ConnectionString = "Data Source = DAL/DB/social_network.db; Version = 3";

        /// <summary>
        /// Получить результирующую строку SQL-запроса
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="sql">SQL-запрос</param>
        /// <param name="parameters">Параметры SQL-запроса</param>
        /// <returns>Результирующая строка SQL-запроса</returns>
        protected T? QueryFirstOrDefault<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            connection.Open();
            return connection.QueryFirstOrDefault<T>(sql, parameters);
        }

        /// <summary>
        /// Выполнить SQL-запрос
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="sql">SQL-запрос</param>
        /// <param name="parameters">Параметры SQL-запроса</param>
        /// <returns>Коллекция данных</returns>
        protected List<T> Query<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            connection.Open();
            return connection.Query<T>(sql, parameters).ToList();
        }

        /// <summary>
        /// Выполнить параметризированный скрипт к БД
        /// </summary>
        /// <param name="sql">SQL-скрипт</param>
        /// <param name="parameters">Параметры SQL-скрипта</param>
        /// <returns>Результат выполнения SQL-скрипта</returns>
        protected int Execute(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            connection.Open();
            return connection.Execute(sql, parameters);
        }

        /// <summary>
        /// Создать подключение к БДы
        /// </summary>
        /// <returns>Подключение к БД</returns>
        private IDbConnection CreateConnection() => new SQLiteConnection(ConnectionString);
    }
}
