using Moq;
using NUnit.Framework.Internal;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddFriendThrowsArgumentNullException()
        {
            var userAddingFriendData = new UserAddingFriendData
            {
                CurrentUserId = 1,
                FriendEmail = string.Empty,
            };

            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(u => u.FindByEmail("test@gmail.com")).Returns(new UserEntity()
            {
                id = 2
            });

            var mockFriendRepository = new Mock<IFriendRepository>();

            mockFriendRepository.Setup(f => f.Create(new FriendEntity { user_id = 1, friend_id = 2 })).Returns(1);

            var userService = new UserService(mockUserRepository.Object, mockFriendRepository.Object);

            Assert.Throws<ArgumentNullException>(() => userService.AddFriend(userAddingFriendData));
        }
    }
}