using Customers.API.Services;

namespace Customers.API
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}
