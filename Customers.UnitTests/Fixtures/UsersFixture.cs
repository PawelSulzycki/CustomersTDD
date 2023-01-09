namespace Customers.UnitTests.Fixtures
{
    internal static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User()
                {
                    Id = 1,
                    Name = "Pawel",
                    Email = "pawel@example.com"
                },
                new User()
                {
                    Id = 1,
                    Name = "Jan",
                    Email = "jan@example.com"
                },
            };
    }
}
