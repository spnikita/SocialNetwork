using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с таблицей БД Users
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <inheritdoc />
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
        }

        /// <inheritdoc />
        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        /// <inheritdoc />
        public UserEntity? FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }

        /// <inheritdoc />
        public UserEntity? FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        /// <inheritdoc />
        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }

        /// <inheritdoc />
        public int DeleteById(int id)
        {
            return Execute("delete from users where id = :id_p", new { id_p = id });
        }
    }
}
