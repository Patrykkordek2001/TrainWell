using Moq;
using NuGet.ContentModel;
using TrainWell___BACKEND.Dtos.Users;
using TrainWell___BACKEND.Models.Users;
using TrainWell___BACKEND.Services;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;
using Xunit;

namespace TrainWell___BACKEND.Tests
{
    public class AuthServiceTests
    {
        private readonly IAuthService _authService;
        private readonly ISqlRepository<User> _authRepository;
        public AuthServiceTests(IAuthService authService, ISqlRepository<User> authRepository)
        {
            _authService = authService;
            _authRepository = authRepository;
        }

        [Fact]
        public async Task AuthenticateUser_ValidCredentials_ReturnsUser()
        {
            var userDto = new UserDto("testuser", "testpassword");
            var mockRepository = new Mock<ISqlRepository<User>>();
            var mockAuthService = new Mock<AuthService>(mockRepository.Object); 

            var userInRepository = new User("testuser", _authService.HashPassword("testpassword"), "email@test.pl");
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User> { userInRepository });

            var result = await mockAuthService.Object.AuthenticateUser(userDto);

            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        //[Fact]
        //public async Task AuthenticateUser_InvalidCredentials_ReturnsNull()
        //{
        //    // Arrange
        //    var userDto = new UserDto { Username = "invaliduser", Password = "invalidpassword" };
        //    var mockRepository = new Mock<IAuthRepository>();
        //    var mockAuthService = new Mock<AuthService>(mockRepository.Object); // Uwaga: Tu powinieneś dostarczyć prawdziwą implementację repozytorium lub użyć fałszywego repozytorium
        //
        //    // Symuluj dane w repozytorium (brak pasującego użytkownika)
        //    mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<User>());
        //
        //    // Act
        //    var result = await mockAuthService.Object.AuthenticateUser(userDto);
        //
        //    // Assert
        //    Assert.Null(result);
        //}
    }
}
