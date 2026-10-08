using EmployeeTaskManagement.Business.Utilities.Mapping;
using EmployeeTaskManagement.Business.Utilities.Validation.EmployeeDtoValidator;
using EmployeeTaskManagement.Business.Utilities.Validation.TaskItemDtoValidator;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Business.Concrete;

namespace EmployeeTaskManagement.Business
{
    public static class BusinessServiceRegistration{
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<EmployeeProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<TaskItemProfile>());

            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<EmployeeUpdateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<TaskItemCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<TaskItemUpdateDtoValidator>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ITaskItemService, TaskItemManager>();

            return services;
        }
    }
}