using NUnit.Framework;
using SocialConsole.Repositories;

namespace SocialConsole.Tests.Repositories
{
    [TestFixture]
    public class UserRepositoryShould
    {
        private UserRepository _userRepository;

        [SetUp]
        public void Init()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void BeAbleToRegisterAndRetrieveANewUser()
        {
            _userRepository.RegisterUser("alice");
            Assert.That(_userRepository.GetUser("alice").Name, Is.EqualTo("alice"));
        }

        [Test]
        public void ReturnANewlyRegisteredUserToTheCaller()
        {
            var newUser = _userRepository.RegisterUser("alice");
            Assert.That(newUser.Name, Is.EqualTo("alice"));
        }

        [Test]
        public void HaveAnIdempotentRegistrationMethod()
        {
            var newUser1 = _userRepository.RegisterUser("alice");
            var newUser2 = _userRepository.RegisterUser("alice");

            Assert.That(newUser1.Name, Is.EqualTo(newUser2.Name));
        }

        [Test]
        public void NotReRegisterAnExisitingUser()
        {
            _userRepository.RegisterUser("alice");
            _userRepository.RegisterUser("bob");
            _userRepository.RegisterUser("alice");
            Assert.That(_userRepository.GetAllUsers().Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnAListOfAllUsers()
        {
            _userRepository.RegisterUser("alice");
            _userRepository.RegisterUser("bob");
            Assert.That(_userRepository.GetAllUsers().Count, Is.EqualTo(2));
        }
    }
}