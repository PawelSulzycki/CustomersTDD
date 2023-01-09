namespace Customers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockUserService = new Mock<IUsersService>();

            mockUserService
               .Setup(x => x.GetAllUsers())
               .ReturnsAsync(UsersFixture.GetTestUsers());

            var controller = new UsersController(mockUserService.Object);

            // Act
            var result = (OkObjectResult)await controller.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
        {
            // Arrange
            var mockUserService = new Mock<IUsersService>();

            mockUserService
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var controller = new UsersController(mockUserService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            mockUserService.Verify(x => x.GetAllUsers(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockUserService = new Mock<IUsersService>();

            mockUserService
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var controller = new UsersController(mockUserService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            // Arrange
            var mockUserService = new Mock<IUsersService>();

            mockUserService
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var controller = new UsersController(mockUserService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}