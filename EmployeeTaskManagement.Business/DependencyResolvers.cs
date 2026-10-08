using EmployeeTaskManagement.Business.Utilities.Mapping;
using EmployeeTaskManagement.Business.Utilities.Validation.EmployeeDtoValidator;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Business.Concrete;

namespace EmployeeTaskManagement.Business
{
    public static class BusinessServiceRegistration{
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
                cfg.AddProfile<TaskItemProfile>();
                cfg.AddProfile<UserProfile>();
            });

            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ITaskItemService, TaskItemManager>();
            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
