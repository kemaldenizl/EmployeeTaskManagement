using EmployeeTaskManagement.Core.Utilities.Security.Hashing;
using EmployeeTaskManagement.Core.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTaskManagement.Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<HashingHelper>();

            services.AddScoped<ITokenHelper, JwtHelper>();

            return services;
        }
    }
}
