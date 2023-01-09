using Customers.API.Models;

namespace Customers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var controller = new UsersController();

            // Act
            var result = (OkObjectResult)await controller.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserService()
        {
            // Arrange
            var mockUserService = new Mock<IUsersService>();

            mockUserService
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var controller = new UsersController(mockUserService.Object);

            // Act
            var result = (OkObjectResult)await controller.Get();

            // Assert
            mockUserService.Verify(x => x.GetAllUsers(), Times.Once());
        }
    }
}