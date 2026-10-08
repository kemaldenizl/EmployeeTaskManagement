using EmployeeTaskManagement.API.Handlers;
using EmployeeTaskManagement.Business;
using EmployeeTaskManagement.DataAccess;
using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

EmployeeTaskManagementContext.ConnectionString =
    builder.Configuration.GetConnectionString("EmployeeTaskManagementContext")
    ?? throw new InvalidOperationException("'EmployeeTaskManagementContext' connection string not found.");

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
