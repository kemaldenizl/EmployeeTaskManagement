using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTaskManagement.DataAccess
{
    public static class DataAccessServiceRegistration 
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
            services.AddScoped<ITaskItemRepository, EfTaskItemRepository>();

            return services;
        }
    }
}